//religious_policy.h
//�ڽ�������

#include<string>

using namespace std;

#ifndef RELIGIOUS_POLICY_H
#define RELIGIOUS_POLICY_H

class religious_policy	//�ڽ�����
{
public:
	religious_policy ( string name );
	string get_name ();	//����ڽ�������
private:
	string name;	//�ڽ�������
};

#endif