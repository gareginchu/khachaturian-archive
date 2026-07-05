module Pages.Poster

open Feliz

/// The Stage — landing room for the Khachaturian archive.
/// Reinterprets the original CD-ROM design: black stage, a portrait behind,
/// a handwritten musical score overlaid across it, and six floating menu
/// labels — one per interior room, each with its own accent colour.
///
/// The menu categories match the CD 1:1:
///   photobook · timeline · videomaterials · biography · principal works · catalogue
///
/// Each room's accent colour is a CSS variable (--acc-<id>). Interior pages
/// tint their portrait rectangle and menu bullet in the same colour, so the
/// visitor always knows where they are.

// ─── Section data ─────────────────────────────────────────────

type LabelPos = { X: string; Y: string }

type Section = {
    Id: string
    Label: string
    Pos: LabelPos
}

/// Positions are % of the viewport, floating around the score.
let sections : Section list = [
    { Id = "photobook";       Label = "photobook";       Pos = { X = "22%"; Y = "31%" } }
    { Id = "timeline";        Label = "timeline";        Pos = { X = "60%"; Y = "26%" } }
    { Id = "videomaterials";  Label = "videomaterials";  Pos = { X = "47%"; Y = "56%" } }
    { Id = "biography";       Label = "biography";       Pos = { X = "64%"; Y = "60%" } }
    { Id = "principal-works"; Label = "principal works"; Pos = { X = "27%"; Y = "60%" } }
    { Id = "catalogue";       Label = "catalogue";       Pos = { X = "77%"; Y = "50%" } }
]

// ─── The handwritten score overlay ────────────────────────────
// Two staves of five lines each, treble clef, notes, accidentals.
// Every stroke is white on the black stage.

let scoreSvg () : ReactElement =
    Svg.svg [
        svg.viewBox (0, 0, 1200, 400)
        svg.className "score"
        svg.custom ("preserveAspectRatio", "xMidYMid meet")
        svg.children [

            // ── Upper staff — five lines ──
            Svg.g [
                svg.className "staff staff-1"
                svg.children [
                    for i in 0..4 do
                        Svg.path [
                            svg.d (sprintf "M 90 %d C 260 %d 500 %d 720 %d C 900 %d 1080 %d 1150 %d"
                                     (60 + i * 22) (58 + i * 22) (62 + i * 22) (61 + i * 22)
                                     (60 + i * 22) (62 + i * 22) (60 + i * 22))
                        ]
                ]
            ]

            // ── Lower staff ──
            Svg.g [
                svg.className "staff staff-2"
                svg.children [
                    for i in 0..4 do
                        Svg.path [
                            svg.d (sprintf "M 90 %d C 240 %d 460 %d 720 %d C 920 %d 1060 %d 1150 %d"
                                     (220 + i * 22) (218 + i * 22) (222 + i * 22) (221 + i * 22)
                                     (220 + i * 22) (222 + i * 22) (220 + i * 22))
                        ]
                ]
            ]

            // ── Treble clef (approximated, upper staff) ──
            Svg.path [
                svg.className "clef"
                svg.d "M 108 40 C 96 50 92 74 112 96 C 130 116 148 118 148 92 C 148 60 108 60 100 90 C 92 118 108 148 132 152 C 152 156 168 148 168 128 C 168 108 148 100 132 116"
            ]
            Svg.path [
                svg.className "clef"
                svg.d "M 106 200 C 94 210 90 234 110 256 C 128 276 146 278 146 252 C 146 220 106 220 98 250 C 90 278 106 308 130 312 C 150 316 166 308 166 288 C 166 268 146 260 130 276"
            ]

            // ── Notes on upper staff ──
            for x, y in [(240,60); (310,72); (410,50); (460,80); (540,60); (620,90); (710,70); (830,58); (920,86); (1020,66); (1090,80)] do
                Svg.ellipse [
                    svg.cx x
                    svg.cy y
                    svg.rx 10
                    svg.ry 7
                    svg.className "note"
                    svg.custom ("transform", sprintf "rotate(-20 %d %d)" x y)
                ]

            // ── Notes on lower staff ──
            for x, y in [(240,240); (320,222); (430,250); (520,232); (600,264); (700,244); (810,232); (900,262); (990,244); (1080,258)] do
                Svg.ellipse [
                    svg.cx x
                    svg.cy y
                    svg.rx 10
                    svg.ry 7
                    svg.className "note"
                    svg.custom ("transform", sprintf "rotate(-20 %d %d)" x y)
                ]

            // ── Sharps ──
            Svg.g [
                svg.className "accidental sharp"
                svg.children [
                    Svg.path [ svg.d "M 200 40 L 200 90 M 214 34 L 214 84 M 194 56 L 220 52 M 194 74 L 220 70" ]
                    Svg.path [ svg.d "M 590 44 L 590 94 M 604 38 L 604 88 M 584 60 L 610 56 M 584 78 L 610 74" ]
                    Svg.path [ svg.d "M 490 224 L 490 274 M 504 218 L 504 268 M 484 240 L 510 236 M 484 258 L 510 254" ]
                ]
            ]

            // ── X marks (unusual notation, gives it Khachaturian's ink-and-fire feel) ──
            Svg.g [
                svg.className "cross"
                svg.children [
                    Svg.path [ svg.d "M 380 82 L 402 104 M 402 82 L 380 104" ]
                    Svg.path [ svg.d "M 700 246 L 722 268 M 722 246 L 700 268" ]
                    Svg.path [ svg.d "M 940 74 L 962 96 M 962 74 L 940 96" ]
                ]
            ]

            // ── Bar lines ──
            Svg.g [
                svg.className "bars"
                svg.children [
                    for x in [360; 570; 780; 990] do
                        Svg.path [ svg.d (sprintf "M %d 55 L %d 150" x x) ]
                    for x in [370; 580; 790; 1000] do
                        Svg.path [ svg.d (sprintf "M %d 215 L %d 310" x x) ]
                ]
            ]
        ]
    ]

// ─── Menu labels ──────────────────────────────────────────────

let menuLabels () : ReactElement =
    Html.div [
        prop.className "menu-labels"
        prop.children [
            for s in sections do
                Html.a [
                    prop.className (sprintf "menu-label label-%s" s.Id)
                    prop.href (sprintf "/%s" s.Id)
                    prop.style [ style.left (length.percent (float (s.Pos.X.TrimEnd('%')))); style.top (length.percent (float (s.Pos.Y.TrimEnd('%')))) ]
                    prop.text s.Label
                ]
        ]
    ]

// ─── Language switcher ────────────────────────────────────────

let languageSwitcher () : ReactElement =
    Html.nav [
        prop.className "lang-switch"
        prop.ariaLabel "Language"
        prop.children [
            Html.button [ prop.className "lang-btn";        prop.lang "hy"; prop.text "հայերեն";  prop.type' "button" ]
            Html.button [ prop.className "lang-btn";        prop.lang "ru"; prop.text "русский";  prop.type' "button" ]
            Html.button [ prop.className "lang-btn active"; prop.text "english"; prop.type' "button" ]
        ]
    ]

// ─── Controls (bottom right) ──────────────────────────────────

let controls () : ReactElement =
    Html.div [
        prop.className "controls"
        prop.children [
            Html.button [ prop.className "ctrl"; prop.ariaLabel "Close"; prop.type' "button"; prop.text "X" ]
        ]
    ]

// ─── The stage ───────────────────────────────────────────────

let render () =
    Html.main [
        prop.className "stage"
        prop.children [
            // Portrait behind the score.
            Html.div [
                prop.className "stage-portrait"
                prop.children [
                    Html.img [
                        prop.src "/khachaturian-archive/portraits/mature.jpg"
                        prop.alt "Aram Khachaturian, mid-career (source: Aram Khachaturian CD-ROM, 2005)"
                    ]
                ]
            ]
            // Score overlaid across the portrait.
            Html.div [
                prop.className "stage-score"
                prop.children [ scoreSvg () ]
            ]
            // Menu labels floating around the score.
            menuLabels ()
            // Language switcher, controls.
            languageSwitcher ()
            controls ()
        ]
    ]
