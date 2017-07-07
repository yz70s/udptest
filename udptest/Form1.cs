using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace udptest
{
    /*public class packetblock
    {
        int size;
        int receivedcount;
        byte[][] memory;
        int next;
        byte[][] packet;
        int[] used;
        int[] offset;

        public packetblock(int count)
        {
            int a;

            size = count;
            memory=new byte[count][];
            for (a = 0; a < count; a++)
            {
                memory[a] = new byte[1600];
            }
            packet = new byte[count][];
            used = new int[count];
            offset = new int[count];
            clear();
        }

        void clear()
        {
            int a;

            receivedcount = size;
            for (a = 0; a < size; a++)
                used[a] = 0;
            next = 0;
        }

        byte[] getbuffer()
        {
            if (next < size)
            {
                next++;
                return memory[next - 1];
            }
            return null;
        }

        int add(byte[] buffer,int index,int payload_offset)
        {
            if (used[index] == 0)
            {
                packet[index] = buffer;
                used[index] = 1;
                offset[index] = payload_offset;
                receivedcount--;
                return 1;
            }
            return 0;
        }

        byte[] get(int index,ref int payload_offset)
        {
            if (index < size) 
            {
                payload_offset = offset[index];
                return packet[index];
            }
            return null;
        }

        int filled()
        {
            if (receivedcount == 0)
                return 1;
            return 0;
        }
    }*/

    public partial class Form1 : Form
    {
        static int receive_port, receive_count;
        static int send_port;
        static string send_address;
        static int save_data;
        static string caption_string;
        static int running;
        System.Threading.Thread thr;
        static ulong first, last, now, diff, missing, received, wrap;
        static ulong recvlast;

        public Form1()
        {
            InitializeComponent();
            running = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.Sockets.UdpClient udpc;
            int ret;
            int a,c;
            byte[] sendbuffer;

            sendbuffer = new byte[1400];
            for (a = 0; a < 100; a++)
                sendbuffer[a] = (byte)(a & 255);
            udpc = new System.Net.Sockets.UdpClient(13455);

            udpc.Connect(tosendaddr.Text, System.Convert.ToInt32(tosendport.Text, 10));
            c=System.Convert.ToInt32(sendcount.Text,10);
            for (a=0;a < 1/*c*/;a++)
                ret=udpc.Send(sendbuffer, 100);
            udpc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (running == 0)
            {
                if (checkBox1.Checked)
                    save_data = 1;
                else
                    save_data = 0;
                send_port = System.Convert.ToInt32(tosendport.Text, 10);
                send_address = tosendaddr.Text;
                receive_port = System.Convert.ToInt32(toreceiveport.Text, 10);
                receive_count = System.Convert.ToInt32(receivecount.Text, 10);
                caption_string = string.Empty;
                thr = new System.Threading.Thread(Form1.DoWork);
                thr.Start();
                timer1.Enabled = true;
                running = 1;
                button2.Text = "STOP";
            }
            else
            {
                running = 2;
                thr.Join();
                timer1.Enabled = false;
                running = 0;
                button2.Text = "RECEIVE";
            }
        }

        private static void DoWork()
        {
            System.Net.Sockets.UdpClient udpc;
            System.Net.Sockets.Socket sock;
            System.Net.IPEndPoint ipe;
            System.Net.Sockets.UdpClient udpcs;
            byte[] buffer;
            int[] receivedblock;
            int[] differ;
            int a,c;
            int timeout;
            uint sequence_number, sequence_number_next0, sequence_number_next1;
            int expected;
            System.IO.FileStream fil;
            byte[] sendbuffer;
			uint received_sequence_number, received_packet_number;

            fil = null;
            if (save_data == 1)
                fil = new System.IO.FileStream("packets.bin",System.IO.FileMode.Create); //,System.IO.FileAccess.Write,System.IO.FileShare.Read,8*1024*1024,System.IO.FileOptions.WriteThrough);
            buffer = new byte[1600];
            differ = new int[257];
            udpc = new System.Net.Sockets.UdpClient(receive_port);
            ipe = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);

            receivedblock = new int[2];
            receivedblock[0] = receivedblock[1] = receive_count;
            sequence_number = 0;
            sequence_number_next0 = sequence_number + 1;
            sequence_number_next1 = sequence_number + 2;
            sendbuffer = new byte[1400];
            for (a = 0; a < 100; a++)
                sendbuffer[a] = (byte)(a & 255);
            sendbuffer[0] = (byte)((receive_count-1) & 255);
            sendbuffer[1] = (byte)(((receive_count-1) >> 8) & 255);
            sendbuffer[2] = (byte)((sequence_number) & 255);
            sendbuffer[3] = (byte)(((sequence_number) >> 8) & 255);
            sendbuffer[4] = (byte)(((sequence_number) >> 16) & 255);
            sendbuffer[5] = (byte)(((sequence_number) >> 24) & 255);
            sendbuffer[6] = 0;
            udpcs = new System.Net.Sockets.UdpClient(13455);
            udpcs.Connect(send_address, send_port);
            //udpcs.Connect("137.204.48.1", 23456);
            //udpc.Connect("10.0.0.194", 23455);
            sock = udpc.Client;
            sock.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReceiveBuffer, 4 * 1024 * 1024);
            c = receive_count;
            first = 1;
            last = 0;
            wrap = 0;
            missing = 0;
            received = 0;
            recvlast = 0;
            while (true)
            {
                /*receivedblock[0] = receivedblock[1];
                receivedblock[1] = receive_count;*/
                sendbuffer[2] = (byte)((sequence_number) & 255);
                sendbuffer[3] = (byte)(((sequence_number) >> 8) & 255);
                sendbuffer[4] = (byte)(((sequence_number) >> 16) & 255);
                sendbuffer[5] = (byte)(((sequence_number) >> 24) & 255);
                a = udpcs.Send(sendbuffer, 7);
                first = 1;
                timeout = 1;
                expected = 0;
                //while (receivedblock[0] != 0)
                while (expected < receive_count)
                {
                    //if (running == 2)
                    //    break;
                    while (udpc.Available <= 0)
                    {
                        if (timeout > 10000)
                            break;
                        if (running > 1)
                            break;
                        System.Threading.Thread.Sleep(1);
                        if (first != 1)
                            timeout++;
                        if ((timeout % 1000) == 0)
                            a = udpcs.Send(sendbuffer, 7);
                    }
                    if (timeout > 10000)
                        break;
                    if (running > 1)
                        break;
                    timeout = 0;
                    buffer = udpc.Receive(ref ipe);
					// primi 32 bit numero blocco
                    received_sequence_number = (uint)buffer[0] + (uint)buffer[1] * 256 + (uint)buffer[2] * 256 * 256 + (uint)buffer[3] * 256 * 256 * 256;
					// poi 16 bit numero pacchetto
                    received_packet_number = (uint)buffer[4] + (uint)buffer[5] * 256;
                    if (first == 1)
                    {
                        last = (ulong)received_sequence_number * (ulong)receive_count + (ulong)received_packet_number;
                        first = 0;
                    }
                    else
                    {
                        now = (ulong)received_sequence_number * (ulong)receive_count + (ulong)received_packet_number;
                        if (now >= last)
                            diff = now - last;
                        else
                        {
                            diff = 0xffffffffffffffff - last + now + 1;
                            wrap++;
                        }
                        //differ[diff] |= 128;
                        last = now;
                        missing = missing + diff - 1;
                    }
                    if (received_sequence_number == sequence_number_next0)
                    {
                        if (expected == received_packet_number)
                        {
                            expected++;
                            //fil.Write(buffer, 0, buffer.GetUpperBound(0) + 1);
                        }
                        else
                        {
							expected = (int)received_packet_number + 1;
                            /*running = 3;*/
                        }
                        /*receivedblock[0]--;*/
                        if (save_data == 1)
                            fil.Write(buffer, 0, buffer.GetUpperBound(0) + 1);
                    }
                    else if (received_sequence_number == sequence_number_next1)
                    {
						break;
                        /*receivedblock[1]--;*/
                        fil.Write(buffer, 0, buffer.GetUpperBound(0) + 1);
                    }/*
                    else
                    {
                    }*/
                    received++;
                }
                if (timeout > 10000)
                    break;
                if (running > 1)
                    break;
                sequence_number++;
                sequence_number_next0++;
                sequence_number_next1++;
            }
            if (running > 1)
            {
                System.Threading.Thread.Sleep(1000);
                while (udpc.Available > 0)
                {
                    buffer = udpc.Receive(ref ipe);
                }
                sendbuffer[6] = 128;
                if (running == 3)
                    sendbuffer[6] |= 64;
                a = udpcs.Send(sendbuffer, 7);
            }
            udpcs.Close();
            udpc.Close();
            if (save_data == 1)
                fil.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pps;
            pps = (int)(received - recvlast);
            recvlast = received;
            this.Text = "Form1 - " + System.Convert.ToString(received) + " - " + System.Convert.ToString(missing) + " - " + System.Convert.ToString(pps) + "Hz - " + System.Convert.ToString((pps*1400)/(1024*1024)) + " " + System.Convert.ToString(wrap);
        }
    }
}
