#include <stdio.h>
#include <stdlib.h>

void getInput(int*, int*); //declaration of function
int main (int argc, char *argv[]) {

  int i, j, N, current, nextCurrent, T, iterations;
  current = 0;
  nextCurrent = 1;

  getInput(&N, &T); //call function to prompt user input

  double h[2][N][N];

  for (i = 0; i < N; i++ ) {  //initialize array
    for (j = 0; j < N; j++) {
      h[0][i][j] = 0;
      h[1][i][j] = 0;
    }
  }

  //initialize all walls to temperature of 20C
  for (i = 0; i < N; i++) {
    for (j = 0; j < N; j++) {
      h[0][0][i] = 20.0;
      h[0][i][0] = 20.0;
      h[0][N - 1][i] = 20.0;
      h[0][i][N - 1] = 20.0;
      h[0][i][j] = 20.0;
    }
  }

  //define fireplace area
  double fire_start, fire_end;
  fire_start = 0.4 * N;
  fire_end = 0.6 * N;

  //declare temperature of fireplace
  for (i = fire_start; i < fire_end; i++) {
    h[0][0][i] = 100.0;
  }

  printf("\n");
  printf("Initial Temperatures: \n");
  for (i = 0; i < N; i += N/10) {
    for (j = 0; j < N; j += N/10) {
      printf("%-.2f\t", h[current][i][j]);
    }
    printf("\n");
  }

  //iterate through iterations put in by user then calculate new temperatures using the heat equation
  for (iterations = 0; iterations < T; iterations++) {
    for (i = 1; i < N - 1; i++) {
      for (j = 1; j < N - 1; j++) {

        h[nextCurrent][i][j] = 0.25 * (h[current][i - 1][j] + h[current][i + 1][j] + h[current][i][j - 1] + h[current][i][j + 1]);

      }
    }

    current = nextCurrent;
    nextCurrent = 1 - current;
  }



  //finally print the final temperatures after calculations
  printf("\nFinal Temperatures: \n");
  for (i = 0; i < N; i += N / 10) {
    for (j = 0; j < N; j += N / 10) {
      printf("%-.2f\t ", h[current][i][j]);
    }
    printf("\n");
  }


}
/* The following function takes in the pointers for the matrix size and the maximum number of iterations.
 * @param Matrix dimensions pointer
 * @param Maximum number of iterations
 */
void getInput(int* N, int* T) {
  printf("Enter the number of points in each dimension, that is the N value for N x N:\n");
  scanf("%d", N);

  printf("Enter the maximum number of iterations:\n");
  scanf("%d", T);

}