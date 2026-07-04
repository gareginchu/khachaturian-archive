# Aram Khachaturian — Modernist Poster

**Working title.** Repo: `gareginchu/khachaturian-archive`. Public URL (once deployed): <https://gareginchu.github.io/khachaturian-archive/>. Portal: <https://gareginchu.github.io/armenian-composer-heritage/>.

A digital archive around **Aram Ilyich Khachaturian (1903–1978)** — Tiflis-born Armenian-Soviet composer, symphonist, ballet writer, teacher. The hand that wrote the folk voice into the concert hall.

This file is the design and engineering spec for the site. Everything below is grounded in the source CD and treats the composer as a **20th-century modernist**, not a museum antique.

---

## 1. Editorial thesis

Khachaturian is a *20th-century* composer. He shared a stage with Prokofiev and Shostakovich. He conducted his own works in Vienna, London, Rome. He taught. He wrote for cinema. He spoke on the radio — his own voice survives on tape.

The site should feel like a **modernist poster**. Bold typography, generous whitespace, a single warm accent, rhythmic layout that echoes the music. The visitor moves through works, not through eras.

The dominant motif: **the composing hand**. Manuscripts, scores, film title cards, a Sabre Dance played by Jascha Heifetz.

---

## 2. Source material

Read-only source: `C:\Users\gareg\OneDrive\Desktop\Aram Khachatrian`.

- `audio/` — **47 audio files.** Includes:
  - His own voice: `Shneerson -Piano Concerto (Khachaturian's speech).mp3`, `Shneerson -Spartacus (Khachaturian's speech).mp3` — invaluable.
  - Sabre Dance in multiple readings (Heifetz, Galway).
  - First / Second / Third symphonies, Piano Concerto, Violin Concerto, Cello Concerto-Rhapsody.
  - Ballet excerpts: Spartacus (Adagio, Sabre Dance, Atonement), Gayane / Gayaneh, Masquerade waltz.
  - State Anthem of the Armenian SSR.
  - Referenced works by Komitas, Ekmalian, Spendiarian, Sayat Nova (context section).
- `video/` — **14 FLV files.** Adagio, Lezginka, Masquerade, Spartacus final; short documentaries in Armenian / English / Russian; 8 more indexed clips. Transcode FLV → MP4 on ingest.
- `images/photobook/medium/` — **495 photobook images.**
- `images/photobook/small/` — matching thumbnails.
- `images/life/` — 62 life images.
- `images/timeline/` — 31 timeline images.
- `images/works/` — 9 works images.
- `images/media/` — 28 media stills.
- `images/principle/` — 11.
- `xml/life/bio_{arm,eng,rus}.xml` — full trilingual biography.
- `xml/life/brief_{arm,eng,rus}.xml` — trilingual short biography.
- `xml/life/full_bio_{arm,eng,rus}.xml` — extended biography.
- `xml/life/themes_{arm,eng,rus}.xml` — thematic index for the biography.
- `xml/{catalogue,media,photobook,principle,timeline}/*.xml` — structured data per section.
- `Readme CD.doc` — original CD-ROM documentation.

**Encoding.** XML CDATA is encoded Windows-1251 for Russian, likely ArmSCII or Windows-1252 mash for Armenian on this vintage. Normalise everything to UTF-8 on ingest with a per-file confidence flag; where a glyph fails to decode cleanly, mark it `[?]` and log to `ingestion.log`.

**Never fabricate** a date, a title, an opus number, a place, a person, a quotation. If it isn't in these files (or in a source the curator has cited in `src/content/sources.bib`), it does not go on the site.

---

## 3. Design principles

1. **Rhythm before decoration.** Layouts breathe with the pulse of the music they carry. Vertical rhythm is on a strict 8 px baseline; horizontal rhythm on a 12-column grid the eye can feel.
2. **One accent only.** A single chalk-orange, borrowed from Sabre Dance record sleeves of the 1960s.
3. **The hand and the voice.** Manuscripts and Khachaturian's own recorded speeches are the primary primary sources. Everything else supports.
4. **Photo-essay pacing.** Long-form editorial with generous plates, not a card grid. The reader reads.
5. **Modernism, not nostalgia.** No sepia. No aged-paper backgrounds. No Cyrillic-inflected "Soviet chic" as decoration. The site is a 21st-century essay about a 20th-century composer.
6. **Trilingual by default.** Armenian / English / Russian, all treated as first-class.
7. **Slow web.** Static, small JS budget, works on 3G, degrades to a legible document.

Anti-goals: full-bleed hero videos, autoplaying audio, "immersive Spartacus" mode, generative art, AI voice cloning, revolution-poster kitsch, cursor trails.

---

## 4. Design system

### 4.1 Palette

Materials, not swatches. Restraint is the point.

```
--white         #F5F3EE   /* cool paper, warm-shifted just off pure white */
--white-2       #EAE7DE   /* deeper paper, plate backgrounds */
--graphite      #17181C   /* body text, near-black with a cool cast */
--graphite-2    #4A4C55   /* secondary text, captions */
--rule          #C7C4BB   /* hairline dividers */
--chalk-orange  #D14A21   /* the one accent. Chalk-orange. Section numerals, current-item marker, poster titles. */
--stage-blue    #1F3A5F   /* secondary accent, quiet. Timeline strokes only. */
```

Never gradients. Never drop shadows. Lift is done with hairlines and 24 px of margin. The chalk-orange lands *once* per screen. Never two.

### 4.2 Typography

Two families. Editorial pairing.

- **Display sans for posters, headings, work titles, poster numerals.**
  Primary: **Söhne Breit** (Klim) or, licence-free equivalent, **Neue Haas Grotesk Display Pro**. If we cannot license either: **Inter Display** at optical size, tightly tracked.
  Armenian coupling: **Mardoto** (SIL OFL) at matching x-height.
- **Body serif for prose.**
  **GT Sectra** (paid) or, licence-free, **Source Serif 4** at 19 px, line-height 1.6, measure 64–70 ch.
- **Metadata mono.**
  **JetBrains Mono** at 13 px for provenance and opus/date/duration lines.

Rules:
- Never mix serif into a heading. Never mix sans into body prose.
- Poster-scale headings use `letter-spacing: -0.02em` on Latin, natural spacing on Armenian.
- Work titles: display sans small caps, `letter-spacing: 0.08em`. Op. numbers in mono.
- Numerals: tabular figures in tables, lining figures in body.

### 4.3 Grid & spacing

- 12-column grid, 96 px column, 24 px gutter. Content region caps at 1240 px.
- Plates break to viewport edge at ≥1280 px.
- 8 px vertical baseline. Every spacing value a multiple of 8.
- Breakpoints: 360 / 720 / 1024 / 1440 / 1920.

### 4.4 Motion

- Scroll-driven only. No autoplay motion.
- Two vocabularies:
  - **Setting the scene.** 240 ms opacity + 8 px translate on section entry.
  - **Playing the track.** Static waveform lights `--chalk-orange` up to the current playhead. Only motion on the site.
- `prefers-reduced-motion`: entry animations off. Waveform becomes a static bar with a small tick that jumps on the second.

### 4.5 Imagery treatment

- Portraits at native aspect ratio, 24 px of `--white` around them.
- Manuscript pages in an IIIF deep-zoom viewer.
- Poster-style plate: one photograph, one work title, one work-number badge in `--chalk-orange`, one date. Nothing else.
- Never CSS filters over historical images. Never duotones over portraits.
- Video: 16:9 posters with a thin `--rule` border. Native `<video>` element; no third-party player.
- Aspect-ratio boxes pre-reserved to prevent layout shift.

---

## 5. Information architecture

Six rooms. Reachable from a horizontal navigation strip at the top: work titles in small caps, current room marked by a `--chalk-orange` underline.

```
/                     Poster           (landing)
/life                 Life             (biography, photo-essay pacing)
/works                Works            (catalogue: symphonies, concertos, ballets, film scores)
/voice                Voice            (his own recorded speeches, letters, interviews)
/stage                Stage            (video: Spartacus, Gayane, Masquerade, docs)
/sources              Sources & Colophon
```

No search in Phase 1 — the works catalogue is short enough.

---

## 6. Page specifications

Each page is designed as a *spread* — like a modernist magazine, not a database.

### 6.1 `/` — Poster

- Full-viewport plate: a single confirmed portrait of Khachaturian (curator pick from `images/life/`), aligned right; poster-scale headline aligned left in display sans:
  > **KHACHATURIAN**
  > *Aram Ilyich · 1903–1978*
- Below the plate, a single-column short paragraph: 40–60 words framing the archive.
- Six large room-labels aligned as a horizontal strip below: `Life · Works · Voice · Stage · Sources`.
- No CTA button. No hero video. No audio autoplay.
- Small stage-blue statistic strip at the very bottom: `47 recordings · 14 films · 495 photographs · 3 languages`.

### 6.2 `/life`

- Long-form biography as a photo-essay. Sections: *Tiflis · Moscow · War Years · The Cinema · Spartacus · Late Years*. Section titles in display sans small caps with a chalk-orange section numeral.
- Each section gets one large plate breaking the grid and 2–4 paragraphs of body.
- Inline audio pull-quotes: Khachaturian's own voice on the piece under discussion, transcript below the player.
- Every date footnoted to `sources.bib`.
- Trilingual toggle at article head (`AM · EN · RU`); content in `content/life.{am,en,ru}.md`.

### 6.3 `/works`

- The catalogue as an editorial list, not a spreadsheet. Each work is a short spread:
  - Work title in display sans small caps, opus in mono, dates.
  - One plate (score, poster, stage still) if available.
  - A 2–3 sentence curator note.
  - An audio player where a recording ships from the CD.
  - Provenance line at the foot: `Recording · Ensemble · Conductor · Year · Source · Licence`.
- Grouped by form: *Symphonies · Concertos · Ballets · Piano · Film · Song*. Group headers in display sans, `--chalk-orange` rule beneath.
- Phase 1 ships 12–15 works; the CD supports the full catalogue in Phase 3.

### 6.4 `/voice`

- The single room where Khachaturian speaks in his own voice. **This is the site's editorial heart.**
- A short editorial framing about the Shneerson interviews.
- Each speech: audio player + a bilingual transcript (Russian original + English translation) laid out in two columns aligned line-for-line. A curator's paragraph frames what he's about to say.
- No portraits in this room — his voice does the work.

### 6.5 `/stage`

- Video room. Each video: native `<video>` in a 16:9 plate, poster frame from the CD.
- The archive: Adagio, Lezginka, Masquerade, Spartacus final, Armenian / English / Russian documentaries, and 8 further indexed clips.
- Curator note under each; subtitles where the source has them, otherwise a description.
- No autoplay. No looping.

### 6.6 `/sources`

- Bibliography, provenance table for every asset that ships, licences, AI disclosure, credits, contact.
- Same rigour as the sister archive.

---

## 7. AI, used with restraint

Only ever a *lens*, never a *voice*.

### Permitted (Phase 2, after the base site is stable)

1. **Speech-to-text on Khachaturian's own speeches.** Draft Russian transcripts of the two Shneerson recordings; curator reviews and signs off before publishing. Never used to synthesise new speech.
2. **Translation drafts of the Russian transcripts** into English and Armenian, curator-reviewed.
3. **Multilingual search.** Small local vector index over editorial prose (Armenian, English, Russian).
4. **Alt-text drafting** for portraits and score plates. Curator reviewed.
5. **Metadata normalisation** from CD XML (Windows-1251 → UTF-8, ArmSCII → UTF-8).
6. **Video subtitle generation** for the FLV → MP4 documentaries where the CD didn't ship subtitles. Human-reviewed.

### Forbidden

- Generative art or "in-the-style-of-Khachaturian" imagery.
- AI-composed music, even as a sketch.
- Voice cloning of Khachaturian. He is on tape. That is enough.
- Chatbot impersonation.
- AI-restored or AI-colourised historical portraits or film stills.
- Any AI feature not disclosed on `/sources`.

Every AI-touched output logged in `src/data/ai-manifest.yml` in the same commit that ships it.

---

## 8. Technology

### 8.1 Stack (decision pending)

The user has asked for **Fable 5** (F# → JavaScript). Blocked: no .NET SDK on the current machine. Two paths:

- **Fable path.** Fable 5 + Feliz (React DSL) + Vite. Requires .NET 8 SDK.
- **Fallback path.** Astro (SSG) + hand-written CSS.

Design tokens in §4 are stack-independent.

### 8.2 Repository layout (target)

```
/
├── CLAUDE.md                        (this file)
├── package.json
├── vite.config.ts                    (Fable path) or astro.config.mjs (fallback)
├── src/
│   ├── App.fs / App.fsproj           (Fable path) or src/pages/*.astro (fallback)
│   ├── pages/                        (route components)
│   ├── components/
│   │   ├── Plate.*
│   │   ├── PosterPlate.*             (poster-style landing plate)
│   │   ├── AudioPlayer.*             (native + static waveform)
│   │   ├── VideoPlayer.*             (native <video>, no third-party)
│   │   ├── ManuscriptViewer.*        (OpenSeadragon wrapper)
│   │   ├── TrilingualBlock.*
│   │   ├── SpeechTranscript.*        (two-column ru/en aligned)
│   │   ├── WorkEntry.*               (catalogue item)
│   │   └── Caption.*
│   ├── content/
│   │   ├── life.{am,en,ru}.md
│   │   ├── works/*.yml               (catalogue entries)
│   │   ├── voice/*.yml               (speech transcripts + curator notes)
│   │   ├── stage/*.yml               (video entries)
│   │   └── sources.bib
│   ├── data/
│   │   ├── assets.yml
│   │   ├── ai-manifest.yml
│   │   └── media-manifest.yml
│   └── styles/
│       ├── tokens.css
│       ├── type.css
│       └── layout.css
├── public/
│   └── assets/                       (thumbnails, IIIF pyramids)
└── .github/workflows/deploy-pages.yml
```

### 8.3 Media pipeline

- Audio: 128 kbps AAC (m4a) streaming + 320 kbps MP3 download. Static waveforms via peaks JSON at build.
- Video: FLV → MP4 (H.264 + AAC), 720p max, `-movflags +faststart`. Poster frames at 5% of runtime. Store in R2.
- Sheet music / scores: PDF → 300 DPI PNG → IIIF pyramid via `vips dzsave`.
- Images: `sharp` → AVIF + WebP + JPEG at 480 / 1200 / 2400. Blurhash placeholders.

### 8.4 Hosting

- **Site:** GitHub Pages via Actions.
- **Media:** Cloudflare R2 (bucket `khachaturian-archive-media`).
- **Fonts:** self-hosted WOFF2.
- **Analytics:** Plausible self-hosted or none.

### 8.5 JavaScript budget

- Poster, life, sources: 0 KB JS.
- Works, voice: ≤ 24 KB gzipped (audio player + language switcher).
- Stage: ≤ 8 KB gzipped (native video, minimal wiring).
- Manuscript viewer pages, if any: ≤ 130 KB gzipped.

---

## 9. Accessibility

- WCAG 2.2 AA on every page. Axe + pa11y in CI.
- Language tags on every Armenian / Russian passage.
- Keyboard reach on all interactive elements; visible focus in `--chalk-orange`.
- `prefers-reduced-motion` respected.
- Contrast: body ≥ 8:1 on `--white`, small text ≥ 7:1. `--chalk-orange` only ≥18 px or bold.
- Every audio file has a written description; every speech, a transcript.
- Every video has captions (curator-authored or curator-reviewed AI-generated, marked).
- No auto-advancing, no flashing.

---

## 10. Provenance and licensing

`src/data/assets.yml` is the source of truth. Each entry:

```yaml
- id: shneerson-spartacus
  source: CD/audio/Shneerson -Spartacus (Khachaturian's speech).mp3
  dated: 197x                        # verify from CD or curator
  holder: (TK)
  licence: (TK — verify with holder)
  confidence: attributed
  used_on: [/voice]
```

- Uncertain assets do not ship.
- Editorial text: CC BY-NC 4.0 unless overridden per page.
- Historical assets: their own licence, quoted verbatim in the caption.

---

## 11. Editorial standards

- Never invent a date, a title, an opus number, a person, a place, a quotation.
- Every biographical claim cites `sources.bib`, referenced by a footnote number.
- Armenian: script first, Latin transliteration on first use. His name in the biography section is *Արամ Խաչատրյան* (Aram Khachatryan) — the Armenian orthographic form — with *Aram Khachaturian* as the internationally used transliteration everywhere else.
- OS / NS dating disambiguated where the source is unambiguous.
- Work titles: on first mention, work title + opus + form + year. Thereafter, work title alone.

---

## 12. Roadmap

### Phase 1 — the poster stands up (target: 4–6 weeks)
- Design system (§4) live.
- All 6 routes with content shells and real trilingual biography ingested from CD XML.
- 12–15 works on `/works`, each with audio + short curator note.
- The two Shneerson speeches transcribed (Russian first, English translation drafted) on `/voice`.
- 4–6 videos transcoded to MP4 and published on `/stage`.
- `/sources` complete for everything shipped.
- Accessibility audit passing.

### Phase 2 — AI as a lens (target: 4 weeks after Phase 1)
- Speech-to-text + translation drafts for both Shneerson speeches (curator-signed-off).
- Multilingual local search.
- Curator-reviewed alt-text on every plate.
- Metadata normalisation from CD XML → clean UTF-8 YAML.
- Subtitle drafts on the trilingual documentaries.

### Phase 3 — expansion (open-ended)
- Grow `/works` to the full catalogue.
- Publish the remaining 8 video clips.
- Reach out to the Khachaturian Museum in Yerevan for provenance verification and additional scores.
- A dedicated `/manuscripts` room, if any autograph scores can be acquired.

---

## 13. Governance

- **Editor:** Maggie Goshin.
- **Curator (attributions, sources, translation):** TBD, named on `/sources`.
- **Engineer / designer:** working from this file.
- **Change control:**
  - Editorial content: PR + editor approval before merge.
  - Assets: PR + `assets.yml` update + curator note.
  - AI features: PR + `ai-manifest.yml` update + `/sources` copy.

---

## 14. Rules for Claude working in this repo

- Do not add features not in §5, §6, or the roadmap. Ask first.
- Do not modify anything under `C:\Users\gareg\OneDrive\Desktop\Aram Khachatrian` (read-only source CD).
- Do not import content from the sister archive `komitas-archive`.
- Never fabricate a date, place, work title, opus number, quotation, or attribution.
- If about to write biographical text: stop and ask the curator for a source.
- Prefer editing existing files. New files require a reason.
- Every AI-touched output logged in `src/data/ai-manifest.yml` in the same commit.
- The palette in §4.1 is authoritative — `--chalk-orange` lands *once* per screen.
