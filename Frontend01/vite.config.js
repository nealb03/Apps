// vite.config.js
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  // You can customize as needed:
  // root: './',          // if your index.html is in a different folder
  // build: {
  //   outDir: 'dist',
  // },
  server: {
    port: 5173,
  },
})
