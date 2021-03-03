#include <iostream>
#include <windows.h>
#include <string>
#include "src/artifacts/ArtifactClass.h"
#include "src/hero/HeroClass.h"
#include "src/hero/grade/WarriorClass.h"
#include "src/skills/SkillClass.h"
using namespace std;

HeroClass Hero = WarriorClass("Tom");

template<typename Char, typename Traits, typename Allocator>
std::basic_string<Char, Traits, Allocator> operator*
        (size_t n, const std::basic_string<Char, Traits, Allocator> &s) {
    return s * n;
};

template<typename Char, typename Traits, typename Allocator>
std::basic_string<Char, Traits, Allocator> operator*
        (const std::basic_string<Char, Traits, Allocator> s, size_t n) {
    std::basic_string<Char, Traits, Allocator> tmp = s;
    for (size_t i = 0; i < n; ++i) {
        tmp += s;
    }
    return tmp;
};

void clear() {
//    system("cls");
    string indent = "\n";
    cout << indent * 100;
};

int input_int(const string& name)
{
    int a;
    cout << "Введите число "+name+": ";
    cin >> a;
    return a;
}

string input_str(const string& name)
{
    string a;
    cout << "Введите "+name+": ";
    cin >> a;
    return a;
}

int choice(const string& question, const list<string>& variants){
    std::cout << question << std::endl;
    for (const auto& variant : variants){
        std::cout << variant << std::endl;
    }
    return input_int("");
}


void registration(){
    string name = input_str("имя персонажа");
    clear();
    switch (choice("Выбирите класс", list<string>{"1-Воин"})) {
        case 1: Hero = WarriorClass(name);
    }
}
int main() {
    clear();
    SetConsoleCP(CP_UTF8);
    SetConsoleOutputCP(CP_UTF8);
    registration();
    std::cout << Hero.getHeroName() << std::endl;
    std::cout << Hero.getHP() << std::endl;
    return 0;
}
