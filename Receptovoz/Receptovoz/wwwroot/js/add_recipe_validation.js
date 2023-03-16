const addButton = document.getElementById("add-recipe-send")

const recipeNameError = document.getElementById("recipeNameErrorToast")
const kiloCaloriesError = document.getElementById("kiloCaloriesErrorToast")
const ingredientsListError = document.getElementById("ingredientsListErrorToast")
const instructionError = document.getElementById("instructionErrorToast")
const success = document.getElementById("successToast")

let recipeNameErrorToast,
    kiloCaloriesErrorToast,
    ingredientsListErrorToast,
    instructionErrorToast,
    successToast

setTimeout(() => {
    recipeNameErrorToast = new bootstrap.Toast(recipeNameError)
    kiloCaloriesErrorToast = new bootstrap.Toast(kiloCaloriesError)
    ingredientsListErrorToast = new bootstrap.Toast(ingredientsListError)
    instructionErrorToast = new bootstrap.Toast(instructionError)
    successToast = new bootstrap.Toast(success)
}, 100)

if (addButton) {
    addButton.addEventListener("click", (event) => {
        let validFlag = true

        // validating recipe name
        const recipeName = document.getElementById("recipe-name").value

        if (recipeName.length < 8) {
            validFlag = false
            recipeNameErrorToast.show()
        }

        // validating kilocalories
        const kilocalories = document.getElementById("recipe-kilocalories").value

        if (!Number.isInteger(Number(kilocalories))) {
            validFlag = false
            kiloCaloriesErrorToast.show()
        }

        // validating ingredients list
        const ingredientsList = document.getElementById("recipe-ingredients").value

        if (ingredientsList != "") {
            let ingredientsFlag = true
            ingredientsList.split("\n").forEach((ingredientLine) => {
                if (ingredientLine != "") {
                    if (ingredientLine.split(" - ").length != 2) {
                        ingredientsFlag = false
                    }
                }
            })

            if (!ingredientsFlag) {
                validFlag = false
                ingredientsListErrorToast.show()
            }
        }

        // validating instructions
        const instruction = document.getElementById("recipe-instructions").value

        if (instruction == "") {
            validFlag = false
            instructionErrorToast.show()
        }


        // preventing an event
        if (validFlag) {
            successToast.show()
        }
        else {
            event.preventDefault()
        }
    })
}
