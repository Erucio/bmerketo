function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)


function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]')

const validateText = (event) => {

    if (event.target.value.length >= 2)
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "invalid lenght"
}




const validateEmail = (event) => {
    const regEx = /^[^\s@]+@[^\s@]+\.[^\s@]+$/



    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Invalid Email"
}




const validatePassword = (event) => {
    const regEx = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$/



    if (regEx.test(event.target.value))
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Invalid Password"



}
const validateComment = (event) => {




    if (event.target.value.length >= 8)
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    else
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Please type at least a full sentence."

}
const validateConfirmPassword = (event) => {
    const passwordInput = document.getElementById("Password");
    const confirmPasswordInput = event.target;



    if (passwordInput.value === confirmPasswordInput.value)
        document.querySelector(`[data-valmsg-for="${confirmPasswordInput.id}"]`).innerHTML = "";
    else
        document.querySelector(`[data-valmsg-for="${confirmPasswordInput.id}"]`).innerHTML = "Passwords do not match";
}




















//try {
//    const footer = document.querySelector('footer')

//    if (document.body.scrollHeight >= window.innerHeight) {
//        footer.classList.remove('position-fixed-bottom')
//        footer.classList.add('position-static')
//    } else {
//        footer.classList.remove('position-static')
//        footer.classList.add('position-fixed-bottom')
//    }
//}
//catch { }
