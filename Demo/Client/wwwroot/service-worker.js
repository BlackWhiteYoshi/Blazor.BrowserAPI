addEventListener("install", (event) => event.waitUntil(self.skipWaiting()));
addEventListener("activate", (event) => event.waitUntil(self.clients.claim()));
addEventListener("fetch", (event) => { });
