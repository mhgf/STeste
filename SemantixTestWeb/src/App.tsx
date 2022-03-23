import { useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import { Currency } from "./components/Currency/Currency";

function App() {
  const [date, setDate] = useState<Date>(new Date());

  setInterval(() => setDate(new Date()), 1000);

  return (
    <div className="App-main">
      <header className="App-header">
        <text>
          {date.toLocaleTimeString("pt-br", { timeZone: "America/Sao_Paulo" })}
        </text>
      </header>
      <div className="App-conteiner">
        <div className="App-conteiner-header">
          <Currency currency="Dolar"></Currency>
          <Currency currency="Euro"></Currency>
          <Currency currency="Libra"></Currency>
        </div>
      </div>
    </div>
  );
}

export default App;
