#include <stdio.h>
#include <locale.h>
#include<conio.h>
#include<stdlib.h>

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

int main(void) {
    setlocale(LC_ALL, " ");
    return pr1_1();
}