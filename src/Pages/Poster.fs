module Pages.Poster

open Feliz

/// The landing plate. Modernist poster: one big name, one big date, six room labels.
/// See CLAUDE.md §6.1.

let render () =
    Html.main [
        prop.className "poster"
        prop.children [
            Html.header [
                prop.className "poster-plate"
                prop.children [
                    Html.p [
                        prop.className "poster-eyebrow"
                        prop.text "Aram Ilyich"
                    ]
                    Html.h1 [
                        prop.className "poster-name"
                        prop.text "KHACHATURIAN"
                    ]
                    Html.p [
                        prop.className "poster-dates"
                        prop.children [
                            Html.span [ prop.className "dot"; prop.text "" ]
                            Html.span [ prop.text "1903 — 1978" ]
                            Html.span [ prop.className "dot"; prop.text "" ]
                            Html.span [ prop.text "Tiflis · Moscow · Yerevan" ]
                        ]
                    ]
                ]
            ]

            Html.section [
                prop.className "poster-frame"
                prop.children [
                    Html.p [
                        prop.text "A digital archive around Aram Khachaturian — Armenian-Soviet composer, symphonist, ballet writer, teacher. The hand that wrote the folk voice into the concert hall. Edited slowly. Cited before published."
                    ]
                ]
            ]

            Html.nav [
                prop.className "poster-nav"
                prop.children [
                    Html.a [ prop.href "/life";     prop.text "01 · Life" ]
                    Html.a [ prop.href "/works";    prop.text "02 · Works" ]
                    Html.a [ prop.href "/voice";    prop.text "03 · Voice" ]
                    Html.a [ prop.href "/stage";    prop.text "04 · Stage" ]
                    Html.a [ prop.href "/sources";  prop.text "05 · Sources" ]
                ]
            ]

            Html.section [
                prop.className "poster-stats"
                prop.children [
                    Html.div [
                        prop.className "stat"
                        prop.children [
                            Html.span [ prop.className "stat-num"; prop.text "47" ]
                            Html.span [ prop.className "stat-label"; prop.text "recordings" ]
                        ]
                    ]
                    Html.div [
                        prop.className "stat"
                        prop.children [
                            Html.span [ prop.className "stat-num"; prop.text "14" ]
                            Html.span [ prop.className "stat-label"; prop.text "films" ]
                        ]
                    ]
                    Html.div [
                        prop.className "stat"
                        prop.children [
                            Html.span [ prop.className "stat-num"; prop.text "495" ]
                            Html.span [ prop.className "stat-label"; prop.text "photographs" ]
                        ]
                    ]
                    Html.div [
                        prop.className "stat"
                        prop.children [
                            Html.span [ prop.className "stat-num"; prop.text "3" ]
                            Html.span [ prop.className "stat-label"; prop.text "languages" ]
                        ]
                    ]
                ]
            ]

            Html.footer [
                prop.className "site-foot"
                prop.text "Khachaturian · Modernist Poster · edited by Maggie Goshin · CC BY-NC 4.0 unless noted"
            ]
        ]
    ]
