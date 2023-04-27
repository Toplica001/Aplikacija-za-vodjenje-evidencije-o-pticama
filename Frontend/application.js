import { Ptica } from "./ptica.js";

export class Aplikacija {
    constructor(podrucja, osobine) {
        this.podrucja = podrucja;
        this.osobine = osobine;
    }

    crtajAplikaciju(container) {
        // Crtanje div-ova

        this.proba = 0;
        const glavni = document.createElement("div");
        glavni.classList.add("glavniDiv");
        container.prepend(glavni);

        const levi = document.createElement("div");
        levi.classList.add("levi");
        glavni.appendChild(levi);

        this.leviContainer = levi;

        const desni = document.createElement("div");
        desni.classList.add("desni");
        glavni.appendChild(desni);

        this.desniContainer = desni;

        // Crtanje Podrucja

        const divPod = document.createElement("div");
        divPod.classList.add("divPodrucje");
        levi.appendChild(divPod);

        const pLab = document.createElement("label");
        pLab.innerText = "Podrucje: ";
        pLab.setAttribute("for", "podrucja");
        divPod.appendChild(pLab);

        const pSel = document.createElement("select");
        pSel.id = "podrucja";
        divPod.appendChild(pSel);

        for (let p of this.podrucja) {
            const oSel = document.createElement("option");
            oSel.value = p.podrucjeID;
            oSel.innerText = p.podrucjeNaziv;
            pSel.appendChild(oSel);
        }

        // Crtanje Osobina

        const p = document.createElement("p");
        p.innerText = "Osobine: ";
        levi.appendChild(p);

        const tDiv = document.createElement("div");
        tDiv.classList.add("tableDiv");
        levi.appendChild(tDiv);

        for (let ok in this.osobine) {
            const pKljuc = document.createElement("p");
            pKljuc.classList.add("nazivOsobine", "border1");
            pKljuc.innerText = ok;
            tDiv.appendChild(pKljuc);

            const elDiv = document.createElement("div");
            elDiv.classList.add("border2");
            tDiv.appendChild(elDiv);

            for (let os of this.osobine[ok]) {
                const dir = document.createElement("div");
                dir.classList.add("vrednostOsobine");
                elDiv.appendChild(dir);

                const ir = document.createElement("input");
                ir.type = "radio";
                // name pravi grupe radio button-ova. Svaka grupa može da selektuje
                // najviše jedan
                ir.name = ok;
                ir.type = os.tip;
                ir.id = os.vrednost;
                ir.value = os.id;
                dir.appendChild(ir);

                const lir = document.createElement("label");
                lir.innerText = os.vrednost;
                lir.setAttribute("for", os.vrednost);
                dir.appendChild(lir);
            }
        }

        const button = document.createElement("input");
        button.type = "submit";
        button.value = "Pronaci";
        levi.appendChild(button);

        button.onclick = () =>
        {
            this.pretrazi();
        };
    }

    async pretrazi() {
        while (this.desniContainer.firstChild) {
            this.desniContainer.removeChild(this.desniContainer.lastChild);
        }

        const podrucjeID = this.leviContainer.querySelector("select").value;
        const osobineIDs = this.leviContainer.querySelectorAll("input:checked");
        const osobineList = Array.from(osobineIDs).map((p, i) => `[${i}]=${p.value}`)
            .join("&");
        const p = await fetch(`https://localhost:7265/Ptica/PreuzmiPtice/${podrucjeID}?${osobineList}`);
        const ptice = await p.json();

        for (let p of ptice) {
            const ptica = new Ptica(p.id, p.naziv, p.slika, p.brojVidjenja, podrucjeID);
            ptica.crtajPticu(this.desniContainer);
        }
    }
}