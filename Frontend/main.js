import { Aplikacija } from "./application.js";

const promPodrucja = await fetch("https://localhost:7265/Podrucje/PreuzmiPodrcuja");
const podrucja = await promPodrucja.json();

const promOsobine = await fetch("https://localhost:7265/Osobina/PreuzmiOsobine");
const osobine = await promOsobine.json();

/*prom.json()
    .then(p => console.log(p))
    .catch(e => console.log(`Desila se greška: ${e}`));*/

const app = new Aplikacija(podrucja, osobine);
app.crtajAplikaciju(document.body);