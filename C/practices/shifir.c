#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define FILE_SIZE 1000

void encrypt(int text[FILE_SIZE], int key);

void decrypt(int text[FILE_SIZE], int key);

int main(int argc, char *argv[]) {
    char *filename = malloc(sizeof(char));
    char *mode;
    int key;
    filename = argv[1];
    mode = argv[2];
    key = atoi(argv[3]);
    FILE *file;
    int text[FILE_SIZE];
    file = fopen(filename, "r");
    int c = getc(file);
    int i = 0;
    while (c != EOF) {
        text[i] = c;
        c = getc(file);
        i++;
    }
    text[i] = EOF;
    fclose(file);
    i = 0;
    while (text[i] != EOF) {
        printf("%c", text[i]);
        i++;
    }
    switch (*mode) {
        case 'e':
            encrypt(text, key);
            break;
        case 'd':
            decrypt(text, key);
            break;

        default:
            break;
    }
    file = fopen(filename, "w");
    i = 0;
    while (text[i] != EOF) {
        putc(text[i], file);
        i++;
    }
    fclose(file);
    return 0;
}

void encrypt(int text[FILE_SIZE], int key) {
    int i = 0;
    while (text[i] != EOF) {
        text[i] += key;
        i++;
    }
}

void decrypt(int text[FILE_SIZE], int key) {
    int i = 0;
    while (text[i] != EOF) {
        text[i] -= key;
        i++;
    }
}
