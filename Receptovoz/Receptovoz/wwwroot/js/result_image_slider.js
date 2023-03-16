const slides = document.querySelectorAll(".slide")

function hideSlides() {
    slides.forEach((slide) => slide.classList.remove("active"))
}

function showSlide(slide) {
    slide.classList.add("active")
}

slides.forEach((slide) => {
    slide.addEventListener("click", () => {
        hideSlides()
        showSlide(slide)
    })
})

showSlide(slides[0])
