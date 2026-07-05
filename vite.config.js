import { defineConfig } from 'vite'

export default defineConfig({
  base: '/khachaturian-archive/',
  root: '.',
  publicDir: 'public',
  build: {
    outDir: 'dist',
    emptyOutDir: true,
    target: 'es2020',
    sourcemap: false,
  },
  server: {
    port: 5174,
    strictPort: false,
  },
})
