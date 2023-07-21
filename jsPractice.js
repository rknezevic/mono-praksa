
/*Write a function isPalindrome(str) that takes a string as an argument and returns true if the string is a palindrome and false otherwise. 
A palindrome is a word, phrase, number, or other sequences of characters 
that reads the same forward and backward, ignoring spaces, punctuation, and capitalization. */

var punctRE = /[\u2000-\u206F\u2E00-\u2E7F\\'!"#$%&()*+,\-.\/:;<=>?@\[\]^_`{|}~]/g;

function isPalindrome(str){
    str = str.replace(/\s/g, '');
    str = str.replace(punctRE, '');
    str = str.toLowerCase();
    len = Math.floor(str.length / 2);
    for(var i = 0; i<len; i++)
        if(str[i] !== str [str.length - i - 1])
            return false;
    return true; 
}

console.log(isPalindrome("Rac -.ecar"));

var names = ["Mike", "Nancy","Matt","Nancy","Adam","Jenny","Nancy","Carl", "Adam"];

/* Write a function removeDuplicates(arr) that takes an array of primitive types and 
returns a new array with all duplicate entries removed.*/

function removeDuplicates(arr){
    let unique = [...new Set(arr)]; 
    return unique;

}
console.log(names);
console.log(removeDuplicates(names));

/*Write a program that prints the numbers from 1 to 100. 
But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 
For numbers which are multiples of both three and five print “FizzBuzz”. */
var fizz = "Fizz";
var buzz = "Buzz";
function FizzBuzz(){
    for(var i = 1; i < 101 ; i++){

        if((i % 3 == 0) && (i % 5 == 0)){
            console.log(fizz + buzz);
        }

        else if(i % 3 == 0){
            
            console.log(fizz);
        }

        else if(i % 5 == 0){
            console.log(buzz);
        }
        console.log(i);
    }
}
console.log(FizzBuzz());

/*Write a function fibonacci(n) that returns the nth number in the Fibonacci sequence. 
The Fibonacci sequence is a series of numbers where a number is found by adding up the two numbers before it. 
Starting with 0 and 1, the sequence goes 0, 1, 1, 2, 3, 5, 8, 13, 21, and so forth.*/

function fibonacci(n) {
    return n < 1 ? 0
         : n <= 2 ? 1
         : fibonacci(n - 1) + fibonacci(n - 2)
 }

 console.log(fibonacci(10));

