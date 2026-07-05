module App

open Browser.Dom
open Fable.Core.JsInterop

// React 18 client entry via Feliz-style interop.
// See CLAUDE.md §8.5 — JS budget for the poster page is 0 hydration cost beyond React.

let createRoot : obj -> obj = importMember "react-dom/client"
let container = document.getElementById "root"

let reactRoot = createRoot container
reactRoot?render (Pages.Poster.render ())
