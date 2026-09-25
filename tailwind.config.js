/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,jsx}'],
  theme: {
    extend: {
      colors: {
        brand: {
          50: '#eef7f1',
          100: '#d5ecdd',
          200: '#aed9bd',
          300: '#7ec098',
          400: '#4f9f73',
          500: '#2f8058',
          600: '#226746',
          700: '#1c5239',
          800: '#18422f',
          900: '#143728',
        },
      },
    },
  },
  plugins: [],
}
