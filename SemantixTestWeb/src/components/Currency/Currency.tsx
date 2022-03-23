import { useState } from "react";
import CurrencyInput, { CurrencyInputProps } from "react-currency-input-field";
import useSWR from "swr";
import { CurrencyModel } from "../../Models/Currency";

import "./Currency.css";

type CurrencyProp = {
  currency: "Dolar" | "Euro" | "Libra";
};
const fetcher = (params: string) =>
  fetch(`https://localhost:7257/api/Currency/${params}`)
    .then((res) => res.json())
    .then((res) => res as CurrencyModel);

export function Currency(props: CurrencyProp) {
  const [valueInput, setvalueInput] = useState<string | null | undefined>("1");
  const [currency, setCurrency] = useState<CurrencyModel | undefined>();

  const { data, error } = useSWR(props.currency, fetcher);

  const onChangeCurrency: CurrencyInputProps["onValueChange"] = (
    value,
    _,
    values
  ) => {
    console.log(value);
    console.log();
    setvalueInput(values?.value);
  };

  const symbol = () => {
    switch (props.currency) {
      case "Dolar":
        return "US$";
      case "Euro":
        return "€";
      case "Libra":
        return "£";
    }
  };

  const showValues = () => {
    if (!data) return "";

    const calc = (Number(valueInput) * data.bid).toFixed(2);

    const textEuro = `${calc} ${symbol()}`;
    const text = `${symbol()} ${calc} `;

    return (
      <p className="Text-value">{props.currency != "Euro" ? text : textEuro}</p>
    );
  };

  const moneyNames = data?.name.split("/") ?? ["", ""];

  return (
    <div>
      <h2>{`${moneyNames[1]} - ${moneyNames[0]}`}</h2>
      <CurrencyInput
        id="teste"
        prefix="R$"
        value={valueInput ? valueInput : 0}
        onValueChange={onChangeCurrency}
        step={1}
      />
      <p className="Text-equal">=</p>
      {error ? <p className="Text-error">error</p> : showValues()}
    </div>
  );
}
