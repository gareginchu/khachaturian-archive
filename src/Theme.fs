module Theme

/// Design tokens for The Modernist Poster.
/// Cool white, deep graphite, one chalk-orange accent.
/// See CLAUDE.md §4 for the authoritative palette.

module Colors =
    let white       = "#F5F3EE"
    let white2      = "#EAE7DE"
    let graphite    = "#17181C"
    let graphite2   = "#4A4C55"
    let rule        = "#C7C4BB"
    let chalkOrange = "#D14A21"
    let stageBlue   = "#1F3A5F"

module Type =
    /// Display sans for poster titles, work names, section numerals.
    let display = "'Inter', 'Neue Haas Grotesk Display Pro', 'Mardoto', system-ui, sans-serif"
    /// Body serif for prose.
    let body = "'Source Serif 4', Georgia, serif"
    /// Metadata mono.
    let mono = "'JetBrains Mono', ui-monospace, SFMono-Regular, Menlo, monospace"

module Space =
    /// 8 px vertical baseline. All spacing values are multiples of 8.
    let unit = 8
