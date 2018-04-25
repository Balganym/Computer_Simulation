/*
* City.java
* Models a city
*/

// package tsp;

public class City {
    int x;
    int y;
    int id;

    int[][] times = new int[][] {
        {15, 76, 12, 95, 12},
        {65, 15, 64, 81, 92},
        {47, 95, 52, 54, 89},
        {67, 46, 37, 88, 92},
        {98, 13, 93, 83, 36}
    };

    int[][] costs = new int[][] {
        {85, 36, 76, 65, 82},
        {85, 35, 84, 51, 32},
        {97, 85, 72, 44, 79},
        {87, 26, 67, 98, 42},
        {68, 63, 23, 53, 26}
    };

    // Constructs a randomly placed city
    public City() {
        this.x = (int)(Math.random()*200);
        this.y = (int)(Math.random()*200);
    }
    
    // Constructs a city at chosen x, y location
    public City(int x, int y, int id) {
        this.x = x;
        this.y = y;
        this.id = id;
    }
    
    // Gets city's x coordinate
    public int getX(){
        return this.x;
    }
    
    // Gets city's y coordinate
    public int getY(){
        return this.y;
    }

    // Gets city's id
    public int getID(){
        return this.id;
    }
    
    // Gets the distance to given city
    public double distanceTo(City city){
        int otherID = city.getID();
        int time = times[this.id - 1][otherID - 1];
        int cost = costs[this.id - 1][otherID - 1];
        return time * cost;
    }
    
    // Gets the cost of getting to given city
    public int costTo(City city){
        int otherID = city.getID();        
        int cost = costs[this.id - 1][otherID - 1];
        return cost;
    }

    // Gets the time of getting to given city
    public double timeTo(City city){
        int otherID = city.getID();
        int time = times[this.id - 1][otherID - 1];        
        return time;
    }

    @Override
    public String toString(){
        return getX()+", "+getY();
    }
}