using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.Model
{
    public class SmoothTransition
    {
        private Form _currentOpenForm;
        private bool _isTransitioning = false;

        public async Task ShowFormSafely(Form parentForm, Form formToShow, Action<Form> onFormClosed = null)
        {
            if (_isTransitioning) return;
            _isTransitioning = true;

            var button = GetClickedButton(parentForm);
            if (button != null)
                button.Enabled = false;

            try
            {
                // Close existing form smoothly without showing it
                if (_currentOpenForm != null && !_currentOpenForm.IsDisposed)
                {
                    // Ensure the form is not visible during close
                    _currentOpenForm.Visible = false;
                    _currentOpenForm.Opacity = 0;

                    _currentOpenForm.FormClosed += (s, args) => { };
                    _currentOpenForm.Close();
                    await Task.Delay(300); // Reduced delay for better performance
                }

                _currentOpenForm = formToShow;
                _currentOpenForm.StartPosition = FormStartPosition.CenterScreen;
                _currentOpenForm.FormBorderStyle = FormBorderStyle.None;
                _currentOpenForm.Opacity = 0;
                _currentOpenForm.Visible = false; // Start as invisible

                _currentOpenForm.FormClosed += (s, args) =>
                {
                    _currentOpenForm = null;
                    onFormClosed?.Invoke(parentForm);
                };

                // Fade out parent form and fade in new form
                await CrossFadeForms(parentForm, _currentOpenForm, 100, 150);
            }
            finally
            {
                if (button != null)
                {
                    await Task.Delay(300);
                    button.Enabled = true;
                }
                _isTransitioning = false;
            }
        }

        // Cross-fade between two forms
        public async Task CrossFadeForms(Form fadeOutForm, Form fadeInForm, int fadeOutDuration = 30, int fadeInDuration = 30)
        {
            // First fade out the current form completely
            await FadeOutForm(fadeOutForm, fadeOutDuration);
            fadeOutForm.Visible = false;

            // Then show and fade in the new form
            fadeInForm.Show();
            fadeInForm.Visible = true;
            await FadeInForm(fadeInForm, fadeInDuration);
            fadeInForm.Focus();
        }

        // Smooth fade out animation
        public async Task FadeOutForm(Form form, int duration, int steps = 10)
        {
            if (form.IsDisposed) return;

            for (int i = steps; i >= 0; i--)
            {
                if (form.IsDisposed) return;
                form.Opacity = (double)i / steps;
                await Task.Delay(duration / steps);
                Application.DoEvents();
            }

            // Ensure form is completely hidden
            form.Opacity = 0;
            form.Visible = false;
        }

        // Smooth fade in animation
        public async Task FadeInForm(Form form, int duration, int steps = 10)
        {
            if (form.IsDisposed) return;

            form.Opacity = 0;
            form.Visible = true;

            for (int i = 0; i <= steps; i++)
            {
                if (form.IsDisposed) return;
                form.Opacity = (double)i / steps;
                await Task.Delay(duration / steps);
                Application.DoEvents();
            }
            form.Opacity = 1.0;
        }

        public async Task FastFadeIn(Form form, int duration = 60)
        {
            if (form.IsDisposed) return;

            form.Opacity = 0;
            form.Visible = true;
            await Task.Delay(duration / 3);
            form.Opacity = 0.5;
            await Task.Delay(duration / 3);
            form.Opacity = 1.0;
        }

        // Close current form safely without showing
        public async Task CloseCurrentFormSmoothly(int fadeDuration = 100)
        {
            if (_currentOpenForm != null && !_currentOpenForm.IsDisposed)
            {
                await FadeOutForm(_currentOpenForm, fadeDuration);
                _currentOpenForm.Close();
                _currentOpenForm = null;
            }
        }

        // Close form immediately without animation
        public void CloseCurrentForm()
        {
            if (_currentOpenForm != null && !_currentOpenForm.IsDisposed)
            {
                _currentOpenForm.Visible = false;
                _currentOpenForm.Opacity = 0;
                _currentOpenForm.Close();
                _currentOpenForm = null;
            }
        }

        // Smooth exit application
        public async Task SmoothExit(Form parentForm, int fadeDuration = 200)
        {
            // Close any open child forms first
            await CloseCurrentFormSmoothly(fadeDuration / 2);

            // Then fade out and close the parent form
            await FadeOutForm(parentForm, fadeDuration);
            parentForm.Close();
        }

        // Helper method to get the clicked button
        private Button GetClickedButton(Form form)
        {
            var control = form.ActiveControl;
            return control as Button;
        }

        // Method to check if a transition is in progress
        public bool IsTransitioning()
        {
            return _isTransitioning;
        }

        // Method to force stop any ongoing transition
        public void StopTransition()
        {
            _isTransitioning = false;
        }
    }
}