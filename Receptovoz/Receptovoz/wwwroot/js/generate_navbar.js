function generateNavbar() {
    const header = document.querySelector("header")
    const navbar = document.createElement("nav")
    header.append(navbar)

    const navbarContent = document.createElement("div")
    navbarContent.classList.add("top-bar")

    navbarContent.innerHTML += `<a href="#" id="logo-link">Рецептовоз</a>`

    let newsButton = document.createElement("button")
    newsButton.setAttribute("id", "news-button")
    newsButton.classList.add("nav-button")
    newsButton.innerHTML = "Новости"
    navbarContent.appendChild(newsButton)

    let recipesButton = document.createElement("button")
    recipesButton.setAttribute("id", "recipes-button")
    recipesButton.classList.add("nav-button")
    recipesButton.innerHTML = "Рецепты"
    navbarContent.appendChild(recipesButton)

    navbar.appendChild(navbarContent)

    function setNavigation() {
        let logoLink = document.querySelector("#logo-link")
        logoLink.addEventListener("click", (event) => {
            event.preventDefault()
            location.href = "/"
        })

        newsButton = document.querySelector("#news-button")
        newsButton.addEventListener("click", (event) => {
            location.href = "/news/"
        })

        recipesButton = document.querySelector("#recipes-button")
        recipesButton.addEventListener("click", (event) => {
            location.href = "/filtered_recipes"
        })
    }

    setNavigation()
}

generateNavbar()
