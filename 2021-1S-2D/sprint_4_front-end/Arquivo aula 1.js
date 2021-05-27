/* Consegue trasnforma string em int */
console.log("10" / 2);
console.log("10" * 2);
console.log(10 - "2");

/* Em soma, concatena achando que quer virar string */
console.log("10" + 2);

/* var - O JS define o tipo
         Tem escopo de função (consigo chamar ele em qualquer lugar da função) 
         */
var nome = 'Robert'; //String
var idade = 27; //Int

if(true)
{
    var sair = 'roupa de sair';
};
console.log(sair);

/* Let - O JS define o tipo
         Tem escopo de bloco (Só consigo chamar ele onde foi criado) */
if(true)
{
    let casa = 'pijama';
    console.log(casa); //Funciona por estar dentro do if onde foi declarado o let
};
console.log(casa); //Não funciona por estar fora do local de declaração do let

/* Const - Tem escopo de função e de bloco, mas não pode ser sobrescrito */
const rua = 'catatau';
console.log(rua);

/*  -- IÇAMENTO -- */

console.log(banana);
var banana = 'Nanica';
//O resultado é undefined, o que significa que a variável foi pra cima

console.log(banana);
var banana = 'Nanica';
console.log(banana);
//O resultado é undefined e Nanica, uma linha após a outra. Pois no primeiro console log a variável foi definida e no segundo foi exibida

var banana = 'Nanica';
console.log(banana);
//O resultado é Nanica

console.log(banana);
let banana = 'Nanica';
//Let não faz içamento

//------------------------------------------------------------------------------------------------------------------------------------------------------------------

//map() - Percorre todo o array, executa uma função callback para cada um e devolve como um novo array de mesmo tamanho
var numbers = [1, 4, 9];
var doubles = numbers.map(function(num)
{
    return num * 2;
});
console.log(numbers);
console.log(doubles);

//Calculo que traduz fahrenheit para celsius
var fahrenheit = [0, 32, 45, 48, 91, 93, 121];
var celsius = fahrenheit.map(function(item)
{
    return Math.round((item - 32) *5/9);
});
console.log(celsius);

//filter() - Cria um novo array com os elementos que forem verdadeiros da questão passada pela função fornecida, ou seja, filtra algo baseado na função que é chamada nele
function isBigEnough(value)
{
    return value >= 10;
}
var filtered = [12, 5, 8, 130, 44].filter(isBigEnough);
console.log(filtered);

//Filtra números pares
var numeros = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
function buscarNumerosPares(value)
{
    if (value % 2 == 0)
    return value;
}
var numerosPares = numeros.filter(buscarNumerosPares);
console.log(numerosPares);

//reduce() - Pode assumir o papel de modificador de array ou de um agregador(que faz somas, médias, etc). A cada passo o reduce interage com o array e constrói a variável total
var valores = [1.4, 3.3, 3, 5] //Valores do array
var somatoria = valores.reduce(function(total, item) //total-> Variável acumulativa da função callback --- item-> Variável que armazena o valor atual
{
    return total + item; // Ficaria +/- assim: 1-> total=0; item=1.4 || 2-> total=1.4; item=3.3 || 3-> total=4.7; item=3 || 4-> total=7.7; item=5
}, 0);
console.log(somatoria);

//Média
var valores = [1.5, 2, 4, 10];
var media = valores.reduce((total, item, indice, array) => 
{
    total += item;
    if (indice === array.length -1)
    {
        return total / array.length;
    }

    return total;
}, 0);
console.log(media);