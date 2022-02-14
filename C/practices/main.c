#include <stdio.h>
#include <locale.h>
#include <wchar.h>
#include <stdbool.h>

#define STOP '!'

int pr1_1(){
    int a, b;
    scanf_s("%d", &a);
    scanf_s("%d", &b);
    int res = 0;
    for (int i = 0; i < a; i++) {
        res += b;
    }
    printf("%d", res);
    return 0;
}

int pr1_2(){
    int A[10];

    for (int i = 0; i < 10; i++) {
        printf("A[%d]=", i);
        scanf_s("%d", &A[i]);
    }
    int g = 0;
    for (int i = 0; i < 10; i++) {
        if (A[i] % 2 == 0) {
            g += 1;
        }
    }
    printf("%d", g);
    return 0;
}

int pr1_3(){
    char str[100];
    scanf_s("%s", str, 100);
    int h = 0;
    while (str[h] != NULL) {
        if (str[h] == '?') {
            str[h] = '!';
        }
        h++;
    }
    printf("%s", str);
    return 0;
}

int pr1_4(){
    int a, b, c;
    printf("vod a");
    scanf_s("%d", &a);
    printf("vod b");
    scanf_s("%d", &b);
    printf("vod c");
    scanf_s("%d", &c);

    if ((a + b > c) && (b + c > a) && (a + c > b)) {
        printf("Treygol s takimi storonamy syshestvyet:");
        if ((c * c == a * a + b * b) || (a * a == c * c + b * b) || (b * b == a * a + c * c)) {
            printf("pramugol");
        } else {
            printf("ne pramugol");
        }
    } else {
        printf("Treygol s takimi storonamy nesyshestvyet");
    }
    return 0;
}

int pr1_5(){
    double x, result = 1;
    int n;
    printf("Input x: ");
    scanf_s("%lf", &x);
    printf("Input n: ");
    scanf_s("%d", &n);
    printf("%lf^%d = ", x, n);
    while (n != 0) {
        if (n % 2 != 0) result *= x;
        n /= 2;
        x *= x;
    }
    printf("%lf\n", result);
    return 0;
}

int flip_word(){
    char str[100];
    scanf_s("%s", str, 100);
    int h = 0;
    while (str[h] != NULL) {
        h++;
    }
    printf("Dlina %d\n", h);
    for (int i = 0; i < h; ++i) {
        printf("%c", str[i]);
    }
    return 0;
}

int word_model(){
    wchar_t str1[200];
    wchar_t str2[200];
    int scores[] = {4,1,6,8};
    int score1 = 0;
    int score2 = 0;

    scanf_s("%ls\n", str1);
    scanf_s("%ls\n", str2);
    int h = 0;
    while (str1[h] != NULL) {
        score1 += scores[(int)str1[h]-1072];
        h++;
    }

    h = 0;
    while (str2[h] != NULL) {
        score2 += scores[(int)str2[h]-1072];
        h++;
    }
    printf("Score1 %d\n", score1);
    printf("Score1 %ls\n", str1);

    printf("Score2 %d\n", score2);
    printf("Score2 %ls\n", str2);
    return 0;
}

int main(void) {
    setlocale(LC_ALL, "");

    return word_model();
}