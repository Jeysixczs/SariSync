import { initializeApp } from 'firebase/app'
import { getAuth } from 'firebase/auth'
import { initializeFirestore, persistentLocalCache, persistentSingleTabManager } from 'firebase/firestore'

const firebaseConfig = {
  apiKey: import.meta.env.VITE_FIREBASE_API_KEY,
  authDomain: import.meta.env.VITE_FIREBASE_AUTH_DOMAIN,
  projectId: import.meta.env.VITE_FIREBASE_PROJECT_ID,
  storageBucket: import.meta.env.VITE_FIREBASE_STORAGE_BUCKET,
  messagingSenderId: import.meta.env.VITE_FIREBASE_MESSAGING_SENDER_ID,
  appId: import.meta.env.VITE_FIREBASE_APP_ID,
}

const app = initializeApp(firebaseConfig)

export const auth = getAuth(app)

// Persists documents to IndexedDB. On the next page load (or when a listener
// re-subscribes) Firestore can resume from what's cached locally and only
// pull the diff from the server, instead of re-reading every document again
// — meaningfully fewer billed reads on repeat visits within the free quota.
// persistentSingleTabManager: if the admin opens the app in a second browser
// tab, that second tab falls back to memory-only cache rather than sharing
// the lock (simpler than multi-tab persistence; fine for a single-cashier
// workflow). Falls back gracefully to normal getFirestore() behavior in
// unsupported environments (e.g. private browsing) instead of throwing.
export const db = initializeFirestore(app, {
  localCache: persistentLocalCache({ tabManager: persistentSingleTabManager() }),
})

export default app
