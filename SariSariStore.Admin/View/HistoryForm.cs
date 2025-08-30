using SariSariStore.Admin.View.Interface;
using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SariSariStore.Core.Services.Interface;

namespace SariSariStore.Admin
{
    public partial class HistoryForm : Form
    {

        public HistoryForm(IOrderService orderService)
        {
            InitializeComponent();

        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}