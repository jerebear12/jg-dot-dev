# jeremiahgavin.dev

## How To

1. `cd Presentation`
2. `aube install`
2. `npx unocss`
3. `mise run copy-reset`
4. `mise run copy-alpine`
5. `mise run dev`

## What

This is my personal website and blog.

## Why

For fun! Specifically, the fun of learning and sharing parts of my world with others through the power of the internet. 

I wanted to build a website using tools that I find fascinating and think have real value.

One of the main goals behind this was to build a functional site that is very simple. I love simplicity. This exists to bridge simplicity and functionality that would make the old web proud and the modern web jealous. We'll see if we get there.

## How

This is one of my favorite parts.

**The Stack**

Frontend:

1. HTMZ - Low power tools for HTML
2. UnoCSS - Like tailwind, but better
3. Alpine.js - Interactivity and templating
4. Shiki - Code highlighting
5. Markdig - Markdown to HTML

Backend:

1. C#
2. ASP.Net Core
3. PostgreSQL with pg_search
4. Garnet

Dev Tooling

- Mise - Tooling to manage the tooling. Go figure.
- Aube - NPM alternative that is fast(uses PNPM strategy for speed) and written in rust. Seems like it could be vibe-coded, but so far it works.
- Dotnet SDK - For C#
- Caddy - The proxy and static site hosting server of choice.


## Notes

**Q1**: I was wondering how to not copy and paste my header and footer if I'm not using a templating language of some sort. Then I came up with the idea of having one main page, and when clicking away from it, having HTMZ request for the new page, and fill the body of the page with the new HTML returned from the server. Now, the issue is, how do I handle requests to this new page? For example, if it's the /about page, how does my server know to send the /index page's HTML, with the /about page's body?

**A1**: The answer to the above was to leverage razor pages' templating system. I was hoping to go without razor pages, but so far it's been really helpful.

**Q2**: How do I want to store and load blog pages? I was thinking about using plain files, opening them via dotnet on each request, add the internal text to an object and display that. 

**A2**: Why not use plain files for the content, and a database for metadata? I think that could work well.
