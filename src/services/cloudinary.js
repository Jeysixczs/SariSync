// Client-side image uploads via Cloudinary's unsigned upload API.
// No backend/server needed, and no secret key is exposed to the browser —
// the upload preset controls what's allowed (folder, size, formats, etc.)
// from the Cloudinary dashboard.
//
// Requires these two env vars (see .env.example):
//   VITE_CLOUDINARY_CLOUD_NAME
//   VITE_CLOUDINARY_UPLOAD_PRESET

const CLOUD_NAME = import.meta.env.VITE_CLOUDINARY_CLOUD_NAME
const UPLOAD_PRESET = import.meta.env.VITE_CLOUDINARY_UPLOAD_PRESET

/**
 * Uploads a file to Cloudinary and returns its metadata.
 * @param {File} file
 * @param {string} [folder] optional subfolder, e.g. `product-images/{productId}`
 * @returns {Promise<{ url: string, publicId: string }>}
 */
export async function uploadImage(file, folder) {
  if (!CLOUD_NAME || !UPLOAD_PRESET) {
    throw new Error(
      'Cloudinary is not configured. Set VITE_CLOUDINARY_CLOUD_NAME and VITE_CLOUDINARY_UPLOAD_PRESET in your .env file.'
    )
  }

  const formData = new FormData()
  formData.append('file', file)
  formData.append('upload_preset', UPLOAD_PRESET)
  if (folder) formData.append('folder', folder)

  const res = await fetch(
    `https://api.cloudinary.com/v1_1/${CLOUD_NAME}/image/upload`,
    { method: 'POST', body: formData }
  )

  if (!res.ok) {
    const err = await res.json().catch(() => null)
    throw new Error(err?.error?.message || 'Failed to upload image to Cloudinary.')
  }

  const data = await res.json()
  return { url: data.secure_url, publicId: data.public_id }
}
