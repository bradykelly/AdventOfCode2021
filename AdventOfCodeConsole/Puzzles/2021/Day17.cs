namespace AdventOfCodeConsole.Puzzles._2021;

//You should be able to figure out the top y position of the arc based on the height of the target area, right?
//Because the most y velocity you can have while not overshooting the target is the target area's height - 1.
//Therefore you should be able to find the y position based on just the height of the target area and the y
//difference between the top of the target and the starting y position

// If  your starting y-velocity is +100000 at y=0, then you will go up and come back down and cross y=0 again
// with velocity -100001 at the end of the step.  your next y position will be -100001

//- for all y > 0, up until max y, find x<area x start that get you in
//- for all area y start / 2 <= y <= 0, find x> area x start that get you in
//- add the number of positions in the target area(width* height) that you can directly shoot the probe at

public class Day17 : IDay
{
}