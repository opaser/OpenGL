#pragma once
#ifndef SHADER_H
#define SHADER_H
#include <glad/glad.h>
#include <string>
#include <fstream>
#include <sstream>
#include <iostream>
class Shader
{
public:
	
	Shader(const char* vertexPath, const char* fragmentPath);

	virtual ~Shader();
	virtual void use();
	virtual void setBool(const std::string &name, bool value) const;
	virtual void setInt(const std::string &name, int value) const;
	virtual void setFloat(const std::string &name, float value) const;
	virtual unsigned int Program(){ return ID; }
private:
	unsigned int ID;
	virtual void checkCompileErrors(unsigned int shader, std::string type);
};

#endif