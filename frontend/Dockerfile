FROM ubuntu:20.04

RUN apt-get update && apt-get install -y python3 python3-pip

RUN pip install flask 

COPY service1.py /opt/

ENTRYPOINT FLASK_APP=/opt/service1.py flask run --host=0.0.0.0 --port=8080
