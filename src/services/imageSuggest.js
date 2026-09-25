// Suggests a real, freely-licensed stock photo for a product from the
// Pexels API (free, no attribution required, commercial use allowed:
// https://www.pexels.com/license/), based on its name and category.
//
// Pexels doesn't have photos of specific branded packaging (no free-license
// source does — that's owned by the manufacturer or paid stock agencies),
// so this matches the product to a generic search term for *what it is*
// (e.g. "Century Tuna Flakes" -> "canned tuna") and returns the first real
// photo found. It's meant as a starting point the admin can keep or
// override with their own upload — see uploadImage() in cloudinary.js.
//
// Requires VITE_PEXELS_API_KEY in your .env (free key: https://www.pexels.com/api/).
//
// NOTE ON THE KEY: unlike the Cloudinary upload preset, a Pexels API key is
// a real credential and this calls Pexels directly from the browser, so it
// is visible to anyone who opens dev tools. Worst case if someone copies it
// is your free-tier rate limit gets used up (Pexels has no paid tier to be
// billed for) — not a billing risk, just a usage-limit one.

const PEXELS_API_KEY = import.meta.env.VITE_PEXELS_API_KEY

// Ordered keyword -> search term matches, checked against the lowercased
// product name. First match wins. Falls back to a per-category term.
const KEYWORD_QUERIES = [
  ['pancit canton', 'instant noodles pack'],
  ['noodle', 'instant noodles bowl'],
  ['mami', 'instant noodles bowl'],
  ['sardines', 'canned sardines'],
  ['tuna', 'canned tuna'],
  ['corned beef', 'canned meat'],
  ['luncheon meat', 'canned meat'],
  ['spam', 'canned meat'],
  ['pineapple', 'canned pineapple'],
  ['ham', 'ham'],
  ['coca-cola', 'cola bottle'],
  ['sprite', 'soda bottle'],
  ['tru-orange', 'orange soda'],
  ['water', 'bottled water'],
  ['green tea', 'iced tea bottle'],
  ['orange juice', 'orange juice'],
  ['milo', 'chocolate drink'],
  ['coffee', 'instant coffee sachet'],
  ['beer', 'beer bottle'],
  ['light', 'beer can'],
  ['brandy', 'brandy bottle'],
  ['rhum', 'rum bottle'],
  ['gatorade', 'sports drink bottle'],
  ['cola', 'soda bottle'],
  ['chips', 'potato chips bag'],
  ['crackers', 'crackers'],
  ['cornick', 'roasted corn snack'],
  ['nuts', 'mixed nuts'],
  ['chocolate', 'chocolate bar'],
  ['candy', 'candy'],
  ['mint', 'mint candy'],
  ['wafer', 'wafer biscuit'],
  ['polvoron', 'shortbread cookies'],
  ['biscuit', 'biscuits'],
  ['bread', 'white bread loaf'],
  ['pan de sal', 'bread rolls'],
  ['cream-o', 'chocolate sandwich cookies'],
  ['soy sauce', 'soy sauce bottle'],
  ['vinegar', 'vinegar bottle'],
  ['cooking oil', 'cooking oil bottle'],
  ['coconut oil', 'coconut oil bottle'],
  ['catsup', 'ketchup bottle'],
  ['tomato sauce', 'tomato sauce'],
  ['seasoning', 'seasoning packet'],
  ['sinigang', 'soup mix packet'],
  ['sarap', 'seasoning packet'],
  ['salt', 'salt'],
  ['sugar', 'sugar'],
  ['rice', 'rice sack'],
  ['evaporated milk', 'evaporated milk can'],
  ['condensed milk', 'condensed milk can'],
  ['powdered milk', 'powdered milk'],
  ['all purpose cream', 'cooking cream'],
  ['cheese', 'cheese block'],
  ['hotdog', 'hot dog sausage'],
  ['nuggets', 'chicken nuggets'],
  ['soap', 'bar soap'],
  ['shampoo', 'shampoo sachet'],
  ['toothpaste', 'toothpaste tube'],
  ['sanitary napkin', 'personal care product'],
  ['deodorant', 'deodorant roll on'],
  ['baby powder', 'baby powder'],
  ['detergent', 'laundry detergent'],
  ['fabric conditioner', 'fabric softener'],
  ['dishwashing', 'dish soap'],
  ['bleach', 'bleach bottle'],
  ['insect spray', 'insect spray can'],
  ['trash bag', 'garbage bag'],
  ['match', 'matchbox'],
  ['candle', 'white candle'],
  ['marlboro', 'cigarette pack'],
  ['fortune', 'cigarette pack'],
  ['winston', 'cigarette pack'],
  ['philip morris', 'cigarette pack'],
  ['hope menthol', 'cigarette pack'],
  ['notebook', 'notebook'],
  ['pencil', 'pencil'],
  ['ballpen', 'ballpoint pen'],
  ['pad paper', 'notepad paper'],
  ['load card', 'prepaid phone card'],
]

const CATEGORY_FALLBACK_QUERY = {
  'Instant Noodles': 'instant noodles',
  'Canned Goods': 'canned food',
  Beverages: 'soft drink bottle',
  Snacks: 'snack food',
  Bakery: 'bread bakery',
  Condiments: 'condiment bottle',
  Groceries: 'grocery staples',
  Dairy: 'dairy product',
  Frozen: 'frozen food',
  'Personal Care': 'toiletries',
  Household: 'household cleaning supplies',
  Cigarettes: 'cigarette pack',
  Alcohol: 'liquor bottle',
  'School Supplies': 'school supplies',
  'Load & Others': 'phone card',
}

function queryFor(name, category) {
  const lower = (name || '').toLowerCase()
  for (const [kw, q] of KEYWORD_QUERIES) {
    if (lower.includes(kw)) return q
  }
  return CATEGORY_FALLBACK_QUERY[category] || category || 'grocery product'
}

// Small in-memory cache so retyping/backspacing during the same session
// doesn't re-hit the API for a query already looked up.
const cache = new Map()

/**
 * Looks up a single suggested photo URL for a product, based on its name
 * and category. Returns '' if not configured, not found, or on error —
 * callers should treat that as "no suggestion available" and fall back to
 * letting the admin upload their own image.
 * @param {string} name
 * @param {string} category
 * @returns {Promise<string>}
 */
export async function suggestProductImage(name, category) {
  if (!PEXELS_API_KEY || !name?.trim()) return ''

  const query = queryFor(name, category)
  if (cache.has(query)) return cache.get(query)

  try {
    const res = await fetch(
      `https://api.pexels.com/v1/search?query=${encodeURIComponent(query)}&per_page=1`,
      { headers: { Authorization: PEXELS_API_KEY } }
    )
    if (!res.ok) {
      cache.set(query, '')
      return ''
    }
    const data = await res.json()
    const url = data.photos?.[0]?.src?.medium || ''
    cache.set(query, url)
    return url
  } catch {
    cache.set(query, '')
    return ''
  }
}
