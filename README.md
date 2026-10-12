# React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some Oxlint rules.

## API URL configuration

Copy `.env.example` to `.env` in the `campuseats-web` project root and replace the placeholder with your backend URL (without a trailing slash):

```ini
VITE_API_URL=https://your-backend-url.example
```

Restart the development server after changing `.env`. When a backend is available, read this setting in your frontend API code:

```javascript
const API = import.meta.env.VITE_API_URL;

fetch(`${API}/api/menu`);
```

This starter app has no backend integration yet, so the example request above is documentation only. `.env` and other environment files are ignored by Git; `.env.example` is kept as the shared configuration template.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Oxc](https://oxc.rs)
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/)

## React Compiler

The React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).

## Expanding the Oxlint configuration

If you are developing a production application, we recommend using TypeScript with type-aware lint rules enabled. Check out the [TS template](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts) for information on how to integrate TypeScript and Oxlint's TypeScript related rules in your project.
