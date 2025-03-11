const CACHE_NAME = "version-1"; // if we load an image once we can then take the image from the CACHE

// page when app don't have any internet connection
const urlsToCache = ["index.html", "offline.html"];

const self = this;

// Install SERVICE WORKER
self.addEventListener("install", (event) => {
  // prettier-ignore
  event.waitUntil(
    caches.open(CACHE_NAME).then( (cache) => {
        console.log('open cache');
        // we load only once the pages
        return cache.addAll(urlsToCache);
    })
  );
});

// Listen for requests
self.addEventListener("fetch", (event) => {
  // prettier-ignore
  event.respondWith(
    caches.match(event.request).
        then(() => {
            // when we need to fetch something we fetch 
            return fetch(event.request)
                .catch(() => caches.match('offline.html'))
    })
  );
});

//Activate the SERVICE WORKER
self.addEventListener("activate", (event) => {
  // here we want to memorise the data, but only the newest one
  const cacheWhitelist = [];
  cacheWhitelist.push(CACHE_NAME);

  event.waitUntil(
    // here i delete all the previus versions of my data and alwasy keep the newest one
    caches.keys().then((cacheNames) =>
      Promise.all(
        cacheNames.map((cacheName) => {
          if (!cacheWhitelist.includes(cacheName)) {
            return caches.delete(cacheName);
          }
        })
      )
    )
  );
});
