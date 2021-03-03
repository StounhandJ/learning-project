#include <iostream>
#include <windows.h>
#include <string>
#include "src/artifacts/ArtifactClass.h"
#include "src/hero/HeroClass.h"
#include "src/hero/grade/WarriorClass.h"

void clear(){
    system("cls");
}
int main() {
    SetConsoleCP(CP_UTF8);
    SetConsoleOutputCP(CP_UTF8);
    WarriorClass hero = WarriorClass("Tom");
    std::cout << hero.getHP() << std::endl;
    hero.dealt_damage(120);
    std::cout << hero.getHP() << std::endl;
    return 0;
}
