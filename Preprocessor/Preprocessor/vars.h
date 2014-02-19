/* vars.h */
#ifndef vars
#define vars
#ifndef std::string
#include <string>
#else
#pragma warning "String is already included"
#endif
#ifndef std::ifstream || std::ofstream
#include<fstream>
#else
#pragma warning "fstream is always included"
#endif

std::string inputfile;
std::string outputfile;
std::string currentdirectory;
std::fstream inputstream;
std::fstream outputstream;
//char* buffer[1];



#endif