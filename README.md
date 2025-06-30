# Kolme React Project

This repository contains a basic Vite + React setup with authentication utilities and a simple employee management UI.

## Setup

1. Install Node.js (v18 recommended).
2. If starting from scratch run:
   ```bash
   npm create vite@latest kolme-react -- --template react
   ```
   Then install project dependencies:

```bash
cd kolme-react
npm install
npm install axios react-router-dom react-toastify bootstrap classnames
```

3. Start the development server:

```bash
npm run dev
```

The app expects an API server running at `http://localhost:5000/api`.

To create a production build run:

```bash
npm run build
```
