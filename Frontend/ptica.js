export class Ptica {
    constructor(id, naziv, slika, brojVidjenja, podrucjeID) {
        this.id = id;
        this.naziv = naziv;
        this.slika = slika;
        this.brojVidjenja = brojVidjenja;
        this.podrucjeID = podrucjeID;
    }

    crtajPticu(container) {
        this.container = container;

        const pticaDiv = document.createElement("div");
        pticaDiv.classList.add("ptica");
        container.appendChild(pticaDiv);

        this.pticaDiv = pticaDiv;

        const img = document.createElement("img");
        img.src = `https://localhost:7265/${this.slika}`;
        img.alt = `https://localhost:7265/${this.slika}`;
        pticaDiv.appendChild(img);

        img.onclick = () =>
        {
            this.upisiVidjenje();
        };

        const naziv = document.createElement("p");
        naziv.innerHTML = `Naziv: <b>${this.naziv}</b>`;
        pticaDiv.appendChild(naziv);

        const brojVidjenja = document.createElement("p");
        brojVidjenja.classList.add("brojVidjenja");
        brojVidjenja.innerText = `Broj vidjenja: ${this.brojVidjenja}`;
        pticaDiv.appendChild(brojVidjenja);
    }

    async upisiVidjenje() {
        const lat = prompt("Unesi geografsku širinu: ");
        const lon = prompt("Unesi geografsku dužinu: ");

        const p = await fetch(`https://localhost:7265/Ptica/UpisiVidjenje/${this.id}/${this.podrucjeID}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                latitude: lat,
                longitude: lon,
                vreme: new Date().toISOString()
            })
        });

        if (p.ok) {
            this.container.querySelectorAll("img").forEach(element => {
                element.onclick = undefined;
            });

            this.brojVidjenja++;

            const bv = this.pticaDiv.querySelector(".brojVidjenja");
            bv.innerText = `Broj vidjenja: ${this.brojVidjenja}`;
        }
    }
}