#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <stdlib.h>

#define baseMaskCount 32
#define strCIDRCount 50


void IP() {
    int a;
    scanf("%d", &a);
    if (a > 0 && a <= 126) printf("%s", "IP A - 255.0.0.0");
    else if (a >= 128 && a <= 191) printf("%s", "IP B - 255.255.0.0");
    else if (a >= 192 && a <= 223) printf("%s", "IP C - 255.255.255.0");
    else if (a >= 224 && a <= 239) printf("%s", "IP D - 239.255.255.255");
    else if (a >= 240 && a <= 255) printf("%s", "IP E - 247.255.255.255");
    else printf("%s", " 訡 ");
}


int count(char *array, int StrConst) {
    int i = 0;
    for (i; i < StrConst; i++) {
        if (array[i] == '\0' && array[i] != ' ') {
            break;
        }
    }
    return i;
}

void CIDR(void) {
    system("chcp 65001");

    int baseMask[baseMaskCount];
    for (int i = 0; i < baseMaskCount; i++) baseMask[i] = 1;

    int pointChanger = 0;

    char strCIDR[strCIDRCount];
    printf(" CIDR: ");
    scanf("%s", strCIDR, strCIDRCount);
    for (int i = 0; i < strCIDRCount; i++) {
        if (strCIDR[i] == '\n' || strCIDR[i] == ' ') {
            break;
        }
        if (strCIDR[i] == '/') {
            if (i + 2 < count(strCIDR, strCIDRCount)) {
                pointChanger = (strCIDR[i + 1] - '0') * 10;
                pointChanger += (strCIDR[i + 2] - '0');
            } else {
                pointChanger = (strCIDR[i + 1] - '0');
            }
            break;
        }
    }

    for (int i = pointChanger; i < baseMaskCount; i++) baseMask[i] = 0;
    printf("CIDR: ");
    for (int i = 0; i < baseMaskCount; i++) {
        if (i % 8 == 0 && i != 0) printf(".");
        printf("%d", baseMask[i]);
    }

    return 0;
}


void Culcul() {
    char oper;
    float a, b;
    printf(" ");
    scanf("%f", &a);
    printf(" b ");
    scanf("%f", &b);
    printf(" ^*/+- ");
    do {
        scanf("%c", &oper);
    } while (oper == '\n');

    switch (oper) {
        case '*': {
            printf("%f", a * b);
            break;
        }
        case '/': {
            printf("%f", a / b);
            break;
        }
        case '+': {
            printf("%f", a + b);
            break;
        }
        case '-': {
            printf("%f", a - b);
            break;
        }
        case '^': {
            float c = a;
            for (int i = 1; i < b; i++) {
                a = a * c;
            }
            printf("%f", a);
            break;
        }
    }

}

void Pars() {
    char bin;
    int rez = 0;
    while (scanf("%c", &bin) == 1) {
        if (bin != '0' && bin != '1') {
            if (bin == '\n') break;
        }
        rez = rez * 2 + (bin - '0');
    }
    printf("%i\n", rez);
}

void ASCII() {
    for (int i = 0; i < 277; i++) {
        printf("%c", i);
    }
}


int main(void) {
    int a;
    printf(" ");
    scanf("%d", &a);
    switch (a) {
        case 1: {
            Pars();
            break;
        }
        case 2: {
            Culcul();
            break;
        }
        case 3: {
            IP();
            break;
        }
        case 4: {
            CIDR();
            break;
        }
        case 5: {
            ASCII();
            break;
        }
        default: {
            printf(" ");
            break;
        }
    }
    return 0;
}