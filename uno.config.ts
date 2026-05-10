import { defineConfig, presetWind3 } from 'unocss'

export default defineConfig({
  presets: [
    presetWind3({
      dark: 'class',
    }),
  ],
  cli: {
    entry: {
      patterns: ['./**/*.cshtml', './**/*.html'],
      outFile: 'wwwroot/css/app.min.css',
    },
  },
})
