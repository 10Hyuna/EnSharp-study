#include <iostream>
using namespace std;

char c[] = "sejong";

char& find(int ind) {
	return c[ind];
}

int main() {
	find(0) = 'S';

	std::cout << c;
}