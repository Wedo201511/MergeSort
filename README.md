# MergeSort multithreading
HANDS-ON TEST  
TASK 8 DESIGN AND IMPLEMENT AN APPLICATION THAT GENERATES OR ACCEPTS AS INPUT A LIST/ARRAY OF RANDOM NUMBERS, 
AND USES THE MERGE SORT ALGORITHM TO PERFORM AN ASCENDING SORT OF THE LIST/ARRAY ELEMENTS.  
Your solution should: 
• Use C# as implementation language; 
• Utilize multithreading to speed up sorting; 
• Employ behavior-driven development. 

Solution:
1.Intall specFlow for vs2015. specFlow is a BDD tool; so I want to use specFlow to show the behavior-driven development;
2.In the scenero, I want to specify the thread count as a parameter, but my coleague think it is not reasonable. He advised
that start every thread in recurrsion (but in that way we cannot know how many threads will be started),he said "不是每个
async都会有新线程，.net会自己规划的". I am not very sure about this. I will investigate it and then return to give the final answer.
