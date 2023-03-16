function generateFooter() {
    const footer = document.querySelector("footer")

    const contactsLink = document.createElement("a")
    contactsLink.setAttribute("href", "/contacts/")
    contactsLink.innerHTML = "Контакты"
    contactsLink.style.margin = "5px"
    contactsLink.style.marginLeft = "50px"
    contactsLink.style.marginRight = "50px"
    footer.appendChild(contactsLink)

    const upLink = document.createElement("a")
    upLink.setAttribute("id", "up-button")
    upLink.setAttribute("href", "")
    upLink.innerHTML = "Наверх"
    upLink.style.margin = "5px"
    upLink.style.marginLeft = "50px"
    upLink.style.marginRight = "50px"
    footer.appendChild(upLink)

    upLink.addEventListener("click", (event) => {
        event.preventDefault()
        scroll({
            top: 0,
            left: 0,
            behavior: "smooth"
        })
    })
}

generateFooter()
