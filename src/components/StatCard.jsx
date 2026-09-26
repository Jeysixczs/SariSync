export default function StatCard({ icon: Icon, label, value, tone = 'brand' }) {
  const tones = {
    brand: 'bg-brand-50 text-brand-700',
    amber: 'bg-amber-50 text-amber-700',
    red: 'bg-red-50 text-red-700',
    slate: 'bg-slate-100 text-slate-700',
  }
  return (
    <div className="card flex items-center gap-3 p-3 sm:gap-4 sm:p-4">
      <div className={`flex h-10 w-10 shrink-0 items-center justify-center rounded-xl sm:h-12 sm:w-12 ${tones[tone]}`}>
        <Icon size={18} className="sm:hidden" />
        <Icon size={22} className="hidden sm:block" />
      </div>
      <div className="min-w-0">
        <p className="truncate text-lg font-semibold text-slate-800 sm:text-2xl">{value}</p>
        <p className="truncate text-xs text-slate-500 sm:text-sm">{label}</p>
      </div>
    </div>
  )
}
