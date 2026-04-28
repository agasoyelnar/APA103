// 1.Verilmis arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek.

// let arr = [1, 2, 3, 3, 4, 4, 5]
// let say = {}
// let newarr = []
// for (let i = 0; i < arr.length; i++) {
//     let eded = arr[i];
//     if (say[eded] === undefined) {
//         say[eded] = 1;
//     }

//     else {
//         say[eded]++;
//     }
// }

// let index = 0;
// for (let i = 0; i < arr.length; i++) {
//     let eded = arr[i];
//     let varsa = false;

//     for (let j = 0; j < index; j++) {
//         if (newarr[j] === eded) {
//             varsa = true;
//             break;
//         }
//     }

//     if (varsa === false) {
//         newarr[index] = eded;
//         index++;
//     }
// }
// console.log("say", say);
// console.log("newarr", newarr); 



// 2.Verilmis sozun polindrom olub olmadığını yoxlayan alqoritm yazmaq.

// let polindrom = "hoppoh";
// let ters = "";
// for (let i = polindrom.length - 1; i >= 0; i--) {
//     ters += polindrom[i];
// }
// if (polindrom === ters) {
//     console.log("polindromdur");
// }
// else {
//     console.log("polindrom deyil");
// }


// 3.Girilen ededin verilmis arreyde nece elementden kicik oldugunu yazan alqoritim.
// let arr = [10, 5, 20, 33, 3];
// let eded = 8;
// let say = 0;

// for (let i = 0; i < arr.length; i++) {
//     if (arr[i] > eded) {
//         say++;
//     }
// }

// console.log(say);

// 4.Daxil edilen ededin Aboundant ve ya Deficient oldugunu yoxlayan algorithm.(Abundant ədəd öz müsbət bolenlerinin(ozunden basqa) cəmi özündən böyük olan müsbət tam ədədlərə deyilir. Eks halda Deficient eded olur. 12-Aboundant, 13- Deficient)

// let eded = 13;
// let cem = 0;
// for (let i = 1; i < eded; i++) {
//     if (eded % i === 0) {
//         cem += i;
//     }
// }
// if (cem > eded) {
//     console.log("Aboundant");
// }
// else {
//     console.log("Deficient");
// }


// 5.Array-in bütün elementlərini kvadrata yüksəldib yeni array qaytaran funksiya yazın.

function kvadrat(arr) {
    let newarr = [];
    for (let i = 0; i < arr.length; i++) {
        newarr[i]=(arr[i] * arr[i]);
    }
    return newarr;
}
console.log(kvadrat([1, 2, 3, 4, 5]));