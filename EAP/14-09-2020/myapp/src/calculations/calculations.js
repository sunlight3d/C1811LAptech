/*
export function sum(x, y) {
    return x + y
}
*/
export const sum = (x, y) => x + y
//function pointer trong C
const studentA = {
    name: "aaa",
    age: 20
}
studentA.name = "bbbb" //ok 
export var places = [
    {
        name: "Ha Long",
        state: "Quang Ninh",
        carNumber: 44
    },
    {
        name: "XXn ujhe",
        state: "Provein BB",
        carNumber: 22
    },
    {
        name: "BB xx",
        state: "BB province",
        carNumber: 99
    },
    {
        name: "AA ",
        state: "AA Provinceh",
        carNumber: 33   
    }
]

places.forEach(place => {
    const {name, state, carNumber} = place
    console.log(`name = ${name}, state = ${state}, carNumber = ${carNumber}`)
})
//chi lay ra carNumber 
let carNumbers = places.map(place => place.carNumber)
console.log(`carNumbers = ${JSON.stringify(carNumbers)}`)
/*
studentA = {
    name: "xx",
    age: 11
}
*/

//alert(`studentA = ${JSON.stringify(studentA)}`)