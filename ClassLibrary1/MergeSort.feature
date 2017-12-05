Feature: MergeSort
	In order to avoid silly mistakes
	I want to be told the result of the merge sorting

@mySorttag
Scenario: Sort a number array with a specified Count of threads
	Given The array contains 100 elements
	Then Sort the array with  4 threads
	Then Validate the result array is ascending

@mySorttag
Scenario: Sort a number array with recursion
	Given Generate a array which contains 10000000 elements
	Then Sort the array with recursion
	Then Validate the recursion result array is ascending
