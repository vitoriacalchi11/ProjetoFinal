const cards = document.querySelectorAll(".cards");

const dropzones = document.querySelectorAll(".dropzone");

cards.forEach(card => {
    card.addEventListener('dragstart', dragstart)
    card.addEventListener('drag', drag)
    card.addEventListener('dragend', dragend)
})

dropzones.forEach(dropzone => {
    dropzone.addEventListener('dragenter', dragenter)
    dropzone.addEventListener('dragover', dragover)
    dropzone.addEventListener('dragleave', dragleave)
    dropzone.addEventListener('drop', drop)
})


//drag

function dragstart() {
    //console.log('CARD : iniciou o arraste')
    dropzones.forEach(dropzone => { dropzone.classList.add('highlight') })
}
function drag() {
    // console.log('CARD : arastando')
    this.classList.add('selectedCard')
}
function dragend() {
    // console.log('CARD : Acabou o arraste')
    dropzones.forEach(dropzone => { dropzone.classList.remove('highlight') })
    this.classList.remove('selectedCard')
}




//drop
function dragenter() {
    //console.log('Dropzone: entrou')

}

function dragover() {
    // console.log('Dropzone: esta')
    this.classList.add('overZone')
    const selectedCard = document.querySelector('.selectedCard')
    this.appendChild(selectedCard)
}

function dragleave() {
    // console.log('Dropzone: saiu')
    this.classList.remove('overZone')
}

function drop() {
    // console.log('Dropzone: soltou')
    this.classList.remove('overZone')
}
