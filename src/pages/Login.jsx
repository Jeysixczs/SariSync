import { useState } from 'react'
import { Navigate, useLocation, useNavigate } from 'react-router-dom'
import { Store } from 'lucide-react'
import { useAuth } from '../contexts/AuthContext'

const ERROR_MESSAGES = {
  'auth/invalid-credential': 'Invalid email or password.',
  'auth/user-not-found': 'Invalid email or password.',
  'auth/wrong-password': 'Invalid email or password.',
  'auth/email-already-in-use': 'An account with this email already exists.',
  'auth/weak-password': 'Password must be at least 6 characters.',
  'auth/invalid-email': 'Enter a valid email address.',
}

export default function Login() {
  const { user, login, signup } = useAuth()
  const navigate = useNavigate()
  const location = useLocation()
  const [mode, setMode] = useState('login') // 'login' | 'signup'
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')
  const [error, setError] = useState('')
  const [busy, setBusy] = useState(false)

  if (user) return <Navigate to={location.state?.from || '/'} replace />

  function switchMode(next) {
    setMode(next)
    setError('')
    setPassword('')
    setConfirmPassword('')
  }

  async function handleSubmit(e) {
    e.preventDefault()
    setError('')

    if (mode === 'signup' && password !== confirmPassword) {
      setError('Passwords do not match.')
      return
    }

    setBusy(true)
    try {
      if (mode === 'signup') {
        await signup(email, password)
      } else {
        await login(email, password)
      }
      navigate('/')
    } catch (err) {
      setError(ERROR_MESSAGES[err.code] || 'Something went wrong. Please try again.')
    } finally {
      setBusy(false)
    }
  }

  return (
    <div className="flex min-h-screen items-center justify-center bg-slate-100 px-4">
      <div className="w-full max-w-sm">
        <div className="mb-6 flex flex-col items-center gap-2">
          <div className="flex h-14 w-14 items-center justify-center rounded-2xl bg-brand-600 text-white">
            <Store size={28} />
          </div>
          <h1 className="text-xl font-semibold text-slate-800">SariSync Admin</h1>
          <p className="text-sm text-slate-500">
            {mode === 'signup' ? 'Create a new store account' : 'Sign in to manage your store'}
          </p>
        </div>

        <div className="mb-4 grid grid-cols-2 gap-1 rounded-lg bg-slate-200/70 p-1">
          <button
            type="button"
            onClick={() => switchMode('login')}
            className={`rounded-md py-2 text-sm font-medium transition-colors ${
              mode === 'login' ? 'bg-white text-slate-800 shadow-sm' : 'text-slate-500'
            }`}
          >
            Sign in
          </button>
          <button
            type="button"
            onClick={() => switchMode('signup')}
            className={`rounded-md py-2 text-sm font-medium transition-colors ${
              mode === 'signup' ? 'bg-white text-slate-800 shadow-sm' : 'text-slate-500'
            }`}
          >
            Create account
          </button>
        </div>

        <form onSubmit={handleSubmit} className="card space-y-4 p-6">
          {error && (
            <div className="rounded-lg bg-red-50 px-3 py-2 text-sm text-red-600">{error}</div>
          )}
          {mode === 'signup' && (
            <p className="rounded-lg bg-brand-50 px-3 py-2 text-xs text-brand-700">
              This creates a brand-new, empty store — its own products, suppliers, and orders, separate from any other account.
            </p>
          )}
          <div>
            <label className="label">Email</label>
            <input
              type="email"
              required
              className="input"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="admin@sarisync.com"
              autoComplete="email"
            />
          </div>
          <div>
            <label className="label">Password</label>
            <input
              type="password"
              required
              minLength={mode === 'signup' ? 6 : undefined}
              className="input"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="••••••••"
              autoComplete={mode === 'signup' ? 'new-password' : 'current-password'}
            />
          </div>
          {mode === 'signup' && (
            <div>
              <label className="label">Confirm password</label>
              <input
                type="password"
                required
                minLength={6}
                className="input"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                placeholder="••••••••"
                autoComplete="new-password"
              />
            </div>
          )}
          <button type="submit" disabled={busy} className="btn-primary w-full">
            {busy
              ? mode === 'signup'
                ? 'Creating account…'
                : 'Signing in…'
              : mode === 'signup'
              ? 'Create account'
              : 'Sign in'}
          </button>
        </form>

        <p className="mt-4 text-center text-xs text-slate-400">
          {mode === 'signup' ? (
            <>
              Already have an account?{' '}
              <button type="button" className="font-medium text-brand-700 hover:underline" onClick={() => switchMode('login')}>
                Sign in
              </button>
            </>
          ) : (
            <>
              New here?{' '}
              <button type="button" className="font-medium text-brand-700 hover:underline" onClick={() => switchMode('signup')}>
                Create an account
              </button>
            </>
          )}
        </p>
      </div>
    </div>
  )
}
