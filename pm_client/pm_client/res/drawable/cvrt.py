from pathlib import Path;
import cv2;
import numpy;
for pic in Path.cwd().glob("*.png"):
	p=cv2.imread(str(pic),-1);
	(xx,yy,i)=p.shape;
	for x in range(xx):
		for y in range(yy):
			if(p[x][y][3]==0):
				p[x][y]=255;
			else:
				t=p[x][y];
				t[3]=255-(t[0]//3+t[1]//3+t[2]//3);
				#t[0:3]=0;
				#t[2]=255
	cv2.imwrite("o_"+str(pic.name),p);
