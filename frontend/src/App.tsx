// Landing page only (Weekend 2). Copy is Albanian, informal "ti", see docs/brand-book.md.
export default function App() {
  return (
    <main className="landing">
      <header className="landing__header">
        <img
          className="landing__logo"
          src="/terminfiks-logo-light.svg"
          alt="TerminFiks"
          width={1275}
          height={200}
        />
      </header>

      <section className="landing__hero">
        <h1 className="landing__tagline">
          Karrigia plot.
          <br />
          Telefoni në heshtje.
        </h1>
        <p className="landing__pitch">
          Klientët e tu rezervojnë në 30 sekonda pa aplikacion, dhe një kujtesë në WhatsApp
          kujdeset që të vijnë.
        </p>

        {/* Shop sign-up (Flow 1) comes in a later weekend. */}
        <button className="button" type="button" disabled aria-describedby="soon">
          Hap dyqanin
        </button>
        <p id="soon" className="landing__soon">
          Së shpejti. €12 në muaj, 30 ditë falas.
        </p>
      </section>

      <footer className="landing__footer">terminfiks.com</footer>
    </main>
  )
}
