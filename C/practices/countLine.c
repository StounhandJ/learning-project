#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <fcntl.h>

int main(int argc, char *argv[]) {
    char *filename = malloc(sizeof(char));
    int key;
    filename = argv[1];
    key = atoi(argv[2]);
    FILE *file;
    if (file == NULL) {
        perror(filename);
    } else {
        int stringsCount = 1;
        int text[200];
        file = fopen(filename, "r");
        int c = getc(file);
        int i = 0;
        int number = 0;
        while (c != EOF) {
            text[i] = c;
            c = getc(file);
            if (c == '\n') stringsCount++;
            i++;
        }
        text[i] = EOF;
        i = 0;
        while (text[i] != EOF) {
            if (text[i] == '\n') {
                number++;
                i++;
            }
            if (number == key - 1) {
                printf("%c", text[i]);
            }
            if (number == key) break;
            else if (key > stringsCount || key < 1) {
                printf("String does not exist");
                break;
            }
            i++;
        }
        printf("\nStrings: %d", stringsCount);
        fclose(file);
    }
    return 0;
}
