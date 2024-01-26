clear all; 
clc;
clf;
start_time=cputime;

aviobj = avifile('withed11.avi','fps',15,'quality',85,'compression','RLE');

movI=aviread('lww.avi');
subplot(2,2,1);title('原始视频');
movie(movI);


fileinfo = aviinfo('lww.avi');
%对每个帧进行水印嵌入
    %提取视频中的每一帧

for r=1:fileinfo.NumFrames

mov=aviread('lww.avi',r);
movII=aviread('lww.avi',r);

      
    %转化帧为YUV图像格式
    mov1=ind2rgb(mov.cdata,mov.colormap);
    movi=uint8(round(mov1*255));
    a=movi;
    


[ste_cover,len_total]=randlsbhide(a,'message.txt','goal.bmp',213);



 a1=blkproc('goal.bmp',[8,8],'idct2');
   [x1,x2]=size(a1);
   %a_1=double(a1);
   movII.cdata=uint8(a1);
   
   %movII.cdata=a1
   [x3,x4]=size(movII.cdata);
   %movII.colormap=movI.colormap
   
  %movII.colormap=movI.colormap;
   
    aviobj = addframe(aviobj,movII);
    
end
aviobj = close(aviobj);
pause(10)
%用来调试的语句
%finishfileinfo = aviinfo('withwater8.avi')

fileinfo = aviinfo('withed11.avi');

pause(3);
movIII=aviread('withed11.avi',2);
[l1,l2]=size(movIII.cdata);

subplot(2,2,2);title('有水印的视频: ');
mov2 = aviread('withed11.avi');
%[s1,s2]=size(mov2.cdata)
movie(mov2);
